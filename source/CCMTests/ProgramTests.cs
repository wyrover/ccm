using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CCM;
using System.Xml;
using CCMEngine;

namespace CCMTests
{
    [TestClass]
    public class ProgramTests
    {
      [TestMethod]
      public void TestFolderArgumentCreatesDefaultSettings()
      {
         XmlDocument doc =
          Program.LoadConfiguration(new string[] { "folder_to_analyze" });

         ConfigurationFile config = new ConfigurationFile(doc);
         Assert.AreEqual("folder_to_analyze", config.AnalyzeFolders[0]);
         Assert.AreEqual(30, config.NumMetrics);
         Assert.AreEqual(CCMOutputter.TextOutputType, config.OutputType);
      }

      [TestMethod]
      public void TestCreateConfigurationFromArgsPassingOnlyPathOutputDoesNotOutputAsXML()
      {
        XmlDocument doc = Program.CreateConfigurationFromArgs(new string[] { "c:\\code" });

        ConfigurationFile config = new ConfigurationFile(doc);

        Assert.AreEqual(CCMOutputter.TextOutputType, config.OutputType);
        Assert.AreEqual("c:\\code", config.AnalyzeFolders[0]);
      }

      [TestMethod]
      public void TestCreateConfigurationFromArgsWithXMLSwitchOutputAsXML()
      {
        XmlDocument doc = Program.CreateConfigurationFromArgs(new string[] { "c:\\code", "/xml" });

        ConfigurationFile config = new ConfigurationFile(doc);

        Assert.AreEqual(CCMOutputter.XmlOutputType, config.OutputType);
        Assert.AreEqual("c:\\code", config.AnalyzeFolders[0]);
      }

      [TestMethod]
      public void TestCreateConfigurationFromArgsWithTabbedOutput()
      {
        XmlDocument doc = Program.CreateConfigurationFromArgs(new string[] { "c:\\code", "/tabbedOutput" });

        ConfigurationFile config = new ConfigurationFile(doc);

        Assert.AreEqual(CCMOutputter.TabbedOutputType, config.OutputType);
        Assert.AreEqual("c:\\code", config.AnalyzeFolders[0]);
      }

    }
}

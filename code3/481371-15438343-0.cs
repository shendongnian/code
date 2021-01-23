    using NUnit.Framework;
        [TestFixture]
        public class GetDocxInnerTextTestFixture
        {
            private string _inputFilepath = @"../../TestFixtures/TestFiles/input.docx";
        
            [Test]
            public void GetDocxInnerText()
            {
                string documentText = DocxInnerTextReader.GetDocxInnerText(_inputFilepath);
        
                Assert.IsNotNull(documentText);
                Assert.IsTrue(documentText.Length > 0);
            }
        }
        
    using System.IO;
    using System.IO.Compression;
    using System.Xml;
        public static class DocxInnerTextReader
        {
            public static string GetDocxInnerText(string docxFilepath)
            {
                string folder = Path.GetDirectoryName(docxFilepath);
                string extractionFolder = folder + "\\extraction";
        
                if (Directory.Exists(extractionFolder))
                    Directory.Delete(extractionFolder, true);
        
                ZipFile.ExtractToDirectory(docxFilepath, extractionFolder);
                string xmlFilepath = extractionFolder + "\\word\\document.xml";
        
                var xmldoc = new XmlDocument();
                xmldoc.Load(xmlFilepath);
        
                return xmldoc.DocumentElement.InnerText;
            }
        }

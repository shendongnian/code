    using System;
    using System.Linq;
    using System.Xml.Linq;
    
    namespace Test
    {
        class Program
        {
            static void Main(string[] args)
            {
                string sampleXml =  @"<DirectoryNode Id=""297fe1ac-ff9b-4c40-ada4-86dc713a9537"" Title=""Root"">" + Environment.NewLine +
                                    @"   <DirectoryNode Id=""80e01248-1170-4393-a327-b97409d51159"" Title=""A"">" + Environment.NewLine +
                                    @"      <DirectoryNode Id=""e6db6d3f-be30-4cdf-b79e-864cc9b52c5f"" Title=""A1"">" + Environment.NewLine +
                                    @"         <DirectoryNode Id=""4368d898-6fb0-4e2f-ba56-edbaf4bd0077"" Title=""A11"" />" + Environment.NewLine +
                                    @"      </DirectoryNode>" + Environment.NewLine +
                                    @"      <DirectoryNode Id=""11c5336b-462e-45dc-b4d3-92032ebc3ae3"" Title=""A2"" />" + Environment.NewLine +
                                    @"   </DirectoryNode>" + Environment.NewLine +
                                    @"   <DirectoryNode Id=""b983fd39-fc2e-43e0-80e6-3808fb47f995"" Title=""B"">" + Environment.NewLine +
                                    @"      <DirectoryNode Id=""433851d6-9935-4adb-9acb-7055c26e85cb"" Title=""B1"">" + Environment.NewLine +
                                    @"         <DirectoryNode Id=""f2602aed-6d97-4e46-9e8a-fb181b28f0c8"" Title=""B11"" />" + Environment.NewLine +
                                    @"      </DirectoryNode>" + Environment.NewLine +
                                    @"   </DirectoryNode>" + Environment.NewLine +
                                    @"   <DirectoryNode Id=""9144d8cf-93c0-4de6-9109-448d396a9e17"" Title=""C"" />" + Environment.NewLine +
                                    @"   <DirectoryNode Id=""182491af-452e-40bc-b51e-59f078db3ad3"" Title=""D"" />" + Environment.NewLine +
                                    @"</DirectoryNode>" + Environment.NewLine +
                                    @"";
    
                XDocument document = XDocument.Parse(sampleXml);
    
                //    Given A11's Id, I want A's Id
                XElement parentDirectory = GetParentDirectory(document.Descendants("DirectoryNode").Single(element => (string) element.Attribute("Title") == "A11"));
                Console.WriteLine(parentDirectory.Attribute("Title").Value);
    
                //    Given A2's Id, I want A's Id
                parentDirectory = GetParentDirectory(document.Descendants("DirectoryNode").Single(element => (string)element.Attribute("Title") == "A2"));
                Console.WriteLine(parentDirectory.Attribute("Title").Value);
    
                //    Given A's Id, I want A's Id
                parentDirectory = GetParentDirectory(document.Descendants("DirectoryNode").Single(element => (string)element.Attribute("Title") == "A"));
                Console.WriteLine(parentDirectory.Attribute("Title").Value);
    
                //    Given B1's Id, I want B's Id
                parentDirectory = GetParentDirectory(document.Descendants("DirectoryNode").Single(element => (string)element.Attribute("Title") == "B1"));
                Console.WriteLine(parentDirectory.Attribute("Title").Value);
    
                Console.ReadLine();
            }
    
            public static XElement GetParentDirectory(XElement element)
            {
                if (element.Parent == element.Document.Root)
                    return element;
    
                return GetParentDirectory(element.Parent);
            }
        }
    }

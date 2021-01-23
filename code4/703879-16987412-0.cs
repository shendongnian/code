    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;
    
    namespace StringThing
    {
        class Program
        {
            static void Main(string[] args)
            {
                string sourceFile = args[0];
                string targetFile = args[1];
    
                Dictionary<string, string> strings = LoadDotNetStrings(sourceFile);
                WriteToTarget(targetFile, strings);
            }
    
            static Dictionary<string, string> LoadDotNetStrings(string file)
            {
                var result = new Dictionary<string, string>();
    
                XmlDocument doc = new XmlDocument();
                doc.Load(file);
    
                XmlNodeList nodes = doc.SelectNodes("//data");
    
                foreach (XmlNode node in nodes)
                {
                    string name = node.Attributes["name"].Value;
                    string value = node.ChildNodes[1].InnerText;
                    result.Add(name, value);
                }
    
                return result;
            }
    
            static void WriteToTarget(string targetFile, Dictionary<string, string> strings)
            {
                StringBuilder bob = new StringBuilder();
    
                bob.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
                bob.AppendLine("<resources>");
    
                foreach (string key in strings.Keys)
                {
                    bob.Append("    ");
                    bob.AppendLine(string.Format("<string name=\"{0}\">{1}</string>", key, strings[key]));
                }
    
                bob.AppendLine("</resources>");
    
                System.IO.File.WriteAllText(targetFile, bob.ToString());
            }
        }
    }

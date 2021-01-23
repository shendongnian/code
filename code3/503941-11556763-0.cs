    using System;
    using System.Linq;
    using System.Xml;
    static class Program {
        static void Main(string[] args) {
            string mixed = @"
    Found two objects:
    Object a
    <object>
        <name>a</name>
        <description></description>
    </object>
    Object b
    <object>
        <name>b</name>
        <description></description>
    </object>
    ";
            string xml = "<FOO>" + mixed + "</FOO>";
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            var xmlFragments = from XmlNode node in doc.FirstChild.ChildNodes 
                               where node.NodeType == XmlNodeType.Element 
                               select node;
            foreach (var fragment in xmlFragments) {
                Console.WriteLine(fragment.OuterXml);
            }
        }
    }

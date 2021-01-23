    using System;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        internal class Program
        {
            static void Main()
            {
                string xml =
    @"<Item>
        <GUID>9A4FA56F-EAA0-49AF-B7F0-8CA09EA39167</GUID>
        <Type>button</Type>
        <Title>Save</Title>
        <Value>submit</Value>
        <Name>btnsave</Name>
        <MaxLen>5</MaxLen>
    </Item>";
                XElement elem = XElement.Parse(xml);
                Guid GuidXml = Guid.Parse(elem.Element("GUID").Value);
                Console.WriteLine(GuidXml);
                string TypeXml = elem.Element("Type").Value;
                Console.WriteLine(TypeXml);
                string NameXml = elem.Element("Name").Value;
                Console.WriteLine(NameXml);
                string TitleXml = elem.Element("Title").Value;
                Console.WriteLine(TitleXml);
            }
        }
    }

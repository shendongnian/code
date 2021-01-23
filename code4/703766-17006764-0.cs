    using System;
    using System.CodeDom.Compiler;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using System.Xml.Serialization;
    using System.Xml.Linq;
    using System.IO;
    
    namespace DAL.XML.PDD.Test
    {
        class Program
        {
            static void Main(string[] args)
            {
                string sampleXML = 
                @"<?xml version='1.0' encoding='us-ascii'?>
                <body xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:xsd='http://www.w3.org/2001/XMLSchema'>
                    <header>
                        <user>BOBBY</user>
                    </header>
                    <in>
                        <customer>0123456789</customer>
                    </in>
                    <out>
                        <cmd>
                            <productid></productid>
                            <price></price>
                            <date></date>
                            <state></state>
                            <type></type>
                        </cmd>
                        <cmd>
                            <productid></productid>
                            <price></price>
                            <date></date>
                            <state></state>
                            <type></type>
                        </cmd>
                    </out>
                    <state>
                        <code></code>
                        <desc></desc>
                    </state>
                </body>";
    
                XDocument doc = XDocument.Parse(sampleXML);
    
                // Create our serializer of type Body, so that we can fill out members
                XmlSerializer serializer = new XmlSerializer(typeof(Body));
    
                // Deserialize the parsed XML into .Net objects
                Body body = (Body)serializer.Deserialize(doc.CreateReader());
    
                // Example that we have parsed correctly - output BOBBY
                Console.WriteLine(body.Header.User);
    
                // Use this to write the xml to a file 
                //TextWriter textWriter = new StreamWriter("Test.xml");
    
                // Serialize this object (back into XML) and write it to the console with empty tags
                serializer.Serialize(Console.Out, body);
    
                Console.ReadLine();
            }
        }
    
        [XmlRoot("body")]
        public class Body
        {
            [XmlElement("header")]
            public Header Header { get; set; }
    
            [XmlElement("in")]
            public In In { get; set; }
                    
            [XmlArray("out")]
            [XmlArrayItem("cmd")]
            public Cmd[] Cmd { get; set; }
    
            [XmlElement("state")]
            public State State { get; set; }
        }
    
        public class In
        {
            [XmlElement("customer")]
            public string Customer { get; set; }
        }
    
        public class Header
        {
            [XmlElement("user")]
            public string User { get; set; }
        }
    
        public class Cmd
        {
            [XmlElement("productid")]
            public string ProductId { get; set; }
    
            [XmlElement("price")]
            public string Price { get; set; }
    
            [XmlElement("date")]
            public string Date { get; set; }
    
            [XmlElement("state")]
            public string State { get; set; }
    
            [XmlElement("type")]
            public string Type { get; set; }
        }
    
        public class State
        {
            [XmlElement("code")]
            public string Code { get; set; }
    
            [XmlElement("desc")]
            public string Desc { get; set; }
        }   
    }

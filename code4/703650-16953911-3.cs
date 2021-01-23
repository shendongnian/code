    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Linq;
    using System.Xml.Serialization;
    
    namespace ConsoleApplication1
    {
        public class Program
        {
            private static void Main(string[] args)
            {
                string testXML = @"<Test>
                                        <Params>
                                            <Param>
                                                <Name>Meaningful Parameter Name</Name>
                                                <Value>1</Value>
                                            </Param>
                                            <Param>
                                                <Name>Meaningful Parameter Name2</Name>
                                                <Value>0</Value>
                                            </Param>
                                        </Params>
                                   </Test>";
    
                XDocument doc = XDocument.Parse(testXML);
                XmlSerializer serializer = new XmlSerializer(typeof (Test));
                Test testDeserialized = (Test) serializer.Deserialize(doc.CreateReader());
    
                foreach (Param param in testDeserialized.Params)
                {
                    Console.WriteLine("Name: " + param.Name + ", Value: " + param.Value);
                }
    
                Console.ReadLine();
            }
        }
    
        [XmlRoot]
        public class Test
        {
            [XmlArray("Params")]
            [XmlArrayItem("Param", typeof (Param))]
            public Param[] Params { get; set; }
        }
    
        public class Param
        {
            [XmlElement("Name")]
            public string Name { get; set; }
    
            [XmlElement("Value")]
            public bool Value { get; set; }
        }
    }

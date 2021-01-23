    using System;
    using System.Linq;
    using System.Windows.Forms;
    using System.IO;
    using System.Xml.Serialization;
    using System.Collections.Generic;
    using System.Xml.Linq;
    
    namespace ExampleSerializer
    {
        class Program
        {
            // example class to serialize
            [Serializable]
            public class SQLBit
            {
                [XmlElement("Name")]
                public string Name { get; set; }
    
                [XmlText]
                public string data { get; set; }
            }
            
            // example class to populate to get test data
            public class example
            {
                public string Name { get; set; }
                public string data { get; set; }
            }
    
            static void Main(string[] args)
            {
                string s = "";
    
                // make a generic and put some data in it from the test
                var ls = new List<example> { new example { Name = "thing", data = "data" }, new example { Name = "thing2", data = "data2" } };
    
                // make a second generic and put data from the first one in using a lambda
                // statement creation method.  If your object returned from DLL is a of a
                // type that implements IEnumerable it should be able to be used.
                var otherlist = ls.Select(n => new SQLBit
                    {
                        Name = n.Name,
                        data = n.data
                    });
    
                // start a new xml serialization with a type.
                XmlSerializer xmler = new XmlSerializer(typeof(List<SQLBit>));
    
                // I use a textwriter to start a new instance of a stream writer
                TextWriter twrtr = new StreamWriter(@"C:\Test\Filename.xml");
                
                // Serialize the stream to the location with the list
                xmler.Serialize(twrtr, otherlist);
 
                // Close
                twrtr.Close();
                // TODO: You may want to put this in a try catch wrapper and make up your 
                // own classes.  This is a simple example.
             }
        }
    }

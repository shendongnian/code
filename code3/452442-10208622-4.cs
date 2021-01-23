    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using System.IO;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var items = new root
                {
                    a = "i belong to a",
                    b = new List<bb>
                    {
                        new bb
                        {
                            bbClass = new List<int>
                            {
                                1,
                                2,
                                3,
                                4,
                                5
                            }
                        },
                        new bb
                        {
                            bbClass = new List<int>
                            {
                                1,
                                2,
                                3,
                                4,
                                5
                            }
                        }
                    }
                };
    
                XmlSerializer serializer = new XmlSerializer(typeof(root));
                
                using (var textWriter = new StreamWriter(@"C:\root.xml"))
                {
                    serializer.Serialize(textWriter, items);
                    textWriter.Close();
                }
    
                using (var stream = new StreamReader(@"C:\root.xml"))
                {
    
                    var yourObject = serializer.Deserialize(stream);
                }
    
                Console.Read();
            }
        }
    
        #region [Classes]
    
        public class root
        {
            public string a { get; set; }
    
            public List<bb> b { get; set; }
        }
    
        public class bb
        {
            [XmlElement("bb")]
            public List<int> bbClass { get; set; }
        }
    
        #endregion
    }

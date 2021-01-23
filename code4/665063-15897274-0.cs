    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Json;
    using System.Text;
    namespace ConsoleApplication1
    {
        [DataContract]
        public class FlatProduct
        {
            [DataMember]
            public string id { get; set; }
    
            [DataMember]
            public string[] cell { get; set; }
        }
        class Program
        {
            static void Main(string[] args)
            {
                var flatProducts = new List<FlatProduct>
                {
                    new FlatProduct { id = "1", cell = new string[2]{"1", "Super Item"} },
                    new FlatProduct { id = "2", cell = new string[2]{"2", "Item 1"} }
                };
                var serializer = new DataContractJsonSerializer(flatProducts.GetType());
                using(MemoryStream stream = new MemoryStream())
                {
                    serializer.WriteObject(stream, flatProducts);
                    stream.Seek(0, SeekOrigin.Begin);
    
                    using (var streamReader = new StreamReader(stream))
                    {
                        string result = streamReader.ReadToEnd();
                    }
                }
            }
        }
    }

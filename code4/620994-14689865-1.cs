    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Runtime.Serialization.Json;
    using System.Runtime.Serialization;
    
    namespace ConsoleApplication1
    {
        [DataContract]
        class MyClass
        {
            [DataMember]
            public double[] array { get; set; }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                GetStuff();
            }
    
            static object GetStuff()
            {
                string str = "{ \"array\" : [0.1, 0.2, 0.3, 0.4] }";
    
                var json = new DataContractJsonSerializer(typeof(MyClass));
                var stream = new MemoryStream(Encoding.UTF8.GetBytes(str));
                var obj = json.ReadObject(stream);
                stream.Close();
                return obj;
            }
        }
    }

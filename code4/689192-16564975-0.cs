    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main()
            {
                new Program().Run();
            }
            void Run()
            {
                Class1 test = new Class1();
                test.Product = "Product";
                test.Price = "£100";
                Test(test);
            }
            void Test<T>(T obj)
            {
                XmlSerializerNamespaces Xsn = new XmlSerializerNamespaces();
                Xsn.Add("", ""); 
                XmlSerializer submit = new XmlSerializer(typeof(T)); 
                StringWriter stringWriter = new StringWriter(); 
                XmlWriter writer = XmlWriter.Create(stringWriter); 
                submit.Serialize(writer, obj, Xsn); 
                var xml = stringWriter.ToString(); // Your xml This is the serialization code. In this Obj is the object to serialize
                Console.WriteLine(xml);  // £ sign is fine in this output.
            }
        }
        [XmlRoot("Class1")]
        public class Class1
        {
            [XmlElement("Product")]
            public string Product
            {
                get;
                set;
            }
            [XmlElement("Price")]
            public string Price
            {
                get;
                set;
            }
        }
    }
	

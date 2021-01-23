    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;
    
    namespace ConsoleApplication1
    {
        public interface IDoTest
        {
            void DoTest();
            void Setup();
        }
        public class TestDBConnection : IDoTest
        {
            public string DBName;
            public void DoTest()
            {
                Console.WriteLine("DoHardComplicated Test");
            }
            public void Setup()
            {
                Console.WriteLine("SetUpDBTest");
            }
        }
        public class PingTest : IDoTest
        {
            public string ServerName;
            public void DoTest()
            {
                Console.WriteLine("MaybeDoAPing");
            }
            public void Setup()
            {
                Console.WriteLine("SetupAPingTest");
            }
        }
    
        public class ListOfToDo : List<IDoTest>, IXmlSerializable
        {    
            #region IXmlSerializable
            public XmlSchema GetSchema(){ return null; }
    
            public void ReadXml(XmlReader reader)
            {
                throw new NotImplementedException();
            }
    
            public void WriteXml(XmlWriter writer)
            {
                foreach (IDoTest test in this)
                {
                    writer.WriteStartElement("IDoTest");
                    writer.WriteAttributeString("AssemblyQualifiedName", test.GetType().AssemblyQualifiedName);
                    XmlSerializer xmlSerializer = new XmlSerializer(test.GetType());
                    xmlSerializer.Serialize(writer, test);
                    writer.WriteEndElement();
                }
            }
             #endregion
        }
    
        internal class Program
        {
            private static void Main(string[] args)
            {
    
                TestDBConnection Do1 = new TestDBConnection { DBName = "SQLDB" };
                PingTest Do2 = new PingTest { ServerName = "AccTestServ_5" };
                ListOfToDo allTest = new ListOfToDo { Do1, (Do2) };
                // Now I want to serialize my list. 
                // Its here where I get the error at allTest
                XmlSerializer x = new XmlSerializer(allTest.GetType());
                StreamWriter writer = new StreamWriter("mySerializedTestSuite.xml");
                x.Serialize(writer, allTest); 
    
            }
        }
    }

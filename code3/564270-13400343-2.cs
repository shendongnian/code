    namespace XmlSerializerTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                Example exampleClass = new Example();
                exampleClass.someClass1 = new ext1.SomeClass(){ Value = "Hello" };
                exampleClass.someClass2 = new ext2.SomeClass(){ Value = "World" };
    
                var xmlSerializer = new XmlSerializer(typeof(Example));
                xmlSerializer.Serialize(Console.Out, exampleClass);
                Console.ReadLine();
            }
        }
    
        [XmlRoot(ElementName = "RootNode", Namespace = "http://fooooo")]
        public class Example
        {
            [XmlElement(ElementName = "Value1", Type = typeof(ext1.SomeClass), Namespace = "ext1")]
            public ext1.SomeClass someClass1 { get; set; }
            [XmlElement(ElementName = "Value2", Type = typeof(ext2.SomeClass), Namespace = "ext2")]
            public ext2.SomeClass someClass2 { get; set; }
        }
    }

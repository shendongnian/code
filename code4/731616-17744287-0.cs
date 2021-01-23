      [XmlIncludeAttribute(typeof(ConcreteFooOne))]
      [XmlIncludeAttribute(typeof(ConcreteFooTwo))]
      [XmlIncludeAttribute(typeof(ConcreteFooThree))]
      [XmlRoot(ElementName = "FooData", Namespace = "http://foo.bar")]
      public abstract partial class AbstractFoo
      {
        // Some abstract props etc.
      }
    
      [XmlRoot(ElementName = "FooData", Namespace = "http://foo.bar")]
      public class ConcreteFooOne : AbstractFoo
      {
        public int MyProp { get; set; }
      }
      [XmlRoot(ElementName = "FooData", Namespace = "http://foo.bar")]
      public class ConcreteFooTwo : AbstractFoo
      {
    
      }
      [XmlRoot(ElementName = "FooData", Namespace = "http://foo.bar")]
      public class ConcreteFooThree : AbstractFoo
      {
    
      }
    
      class Program
      {
        static void Main(string[] args)
        {
          var serializer = new System.Xml.Serialization.XmlSerializer(typeof(AbstractFoo));
          using (var stream = new FileStream("test.txt", FileMode.OpenOrCreate))
          {
            serializer.Serialize(stream, new ConcreteFooOne() { MyProp = 10 });
            stream.Flush();
          }
    
    
          using (var stream = new FileStream("test.txt", FileMode.OpenOrCreate))
          {
            var c = serializer.Deserialize(stream);
          }
        }
      }

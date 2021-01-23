      [XmlIncludeAttribute(typeof(ConcreteFooOne))]
      [XmlIncludeAttribute(typeof(ConcreteFooTwo))]
      [XmlIncludeAttribute(typeof(ConcreteFooThree))]
      [XmlRoot(ElementName = "FooData", Namespace = "http://foo.bar")]  
      public abstract partial class AbstractFoo
      {
        
      }
    
      [XmlRoot(ElementName = "FooData", Namespace = "http://foo.bar")]
      
      public class ConcreteFooOne : AbstractFoo
      {
        public string MyProp { get; set; }
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
        static void Main()
        {          
    
          XmlSerializer xs = new XmlSerializer(typeof(List<AbstractFoo>));
          TextWriter writer = new StreamWriter("test.txt", false);
          var list = new List<AbstractFoo>();
          list.Add(new ConcreteFooOne() { MyProp = "test" });
          list.Add(new ConcreteFooTwo() );
          list.Add(new ConcreteFooThree());
          xs.Serialize(writer, list);
          
          writer.Close();
    
          StreamReader srdr = new StreamReader("test.txt");
          var lst = (List<AbstractFoo>)xs.Deserialize(srdr);
          srdr.Close();          
        }
      }

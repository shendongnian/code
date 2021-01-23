    interface IAssignableFrom<T> {
      void AssignFrom(T source);
    }
    
    public class Bar : IAssignableFrom<Foo> {
      public void AssignFrom(Foo foo){
         //implementation of assignment here
      }
    }
    
    public class Baz : IAssignableFrom<Foo> {
      public void AssignFrom(Foo foo){
         //implementation of assignment here
      }
    }
    
    public class Foo : IAssignableFrom<Foo> {
      public void AssignFrom(Foo foo){
         //implementation of assignment here
      }
    }
    
    public class Program {
      public static void Main(string[] args){
        IDictionary<string, IAssignableFrom<Foo>> dictionary = new Dictionary<string, IAssignableFrom<Foo>>;
    
        dictionary.Add("foo", new Foo());
        dictionary.Add("bar", new Bar());
        dictionary.Add("baz", new Baz());
      }
    }

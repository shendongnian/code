    public interface IProvideDescription { 
      string GetDescription();
    }
    
    public class A : IProvideDescription {
      public string GetDescription() {
        return "I'm an A";
      }
    }
    
    public class B : IProvideDescription {
      public string GetDescription() {
        return "I'm a B";
      }
    }
    
    // to execute:
    
    IProvideDescription x = new A();
    Console.WriteLine(x.GetDescription());
    x = new B();
    Console.WriteLine(x.GetDescription());

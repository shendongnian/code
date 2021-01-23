    public interface Intf {
      void DoSomething();
    }
    
    public class Gen<T>: Intf {
      public void DoSomething() {
        // can use the generic stuff here
      }
    }
    
    public class Da {
    
    }
    
    public class Program {
        public static Intf gen;
        public static void Main(string[] args) {
            gen = new Gen<Da>();
            gen.DoSomething();
        }
    }

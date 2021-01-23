    namespace MyNamespace
    {
        //expose an interface with functions to be called from R
        public interface MyInterface
        {
           string MyFunction(string name);
        }
        
        //create a class that implements the above interface
        public class MyClass : MyInterface
        {
          public string MyFunction(string name)
          {
             return "Hello " + name;
          }
        }
    }

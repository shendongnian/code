    namespace Different 
    {
        public class Class1
        {      
            public static int[] Function1()
            {
               // code to return value
            }
        }
    }
    namespace MyNamespace
    {    
        class Program
        { 
              static void Main(string[] args)
              {
                  // Error
                  var arr = Class1.Function();
                  // you need to use...
                  var arr = Different.Class1.Function();
              }
        }
    }

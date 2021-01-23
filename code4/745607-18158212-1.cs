    using System;
    
    namespace StackOverflowDemo
    {
       public class DemoProgram
       {
          public class Bar
          {}
    
    
          static void Main(string[] args)
          {}
    
          
          //?GrabMethodName
          public void Foo(Bar arg)
          {
             //?DumpNameInStringAssignment
             string methodName = "??";  // Will be changed as necessary by preprocessor
    
             throw new ArgumentException("Argument is incompatible with " + methodName);
          }
       }
    }

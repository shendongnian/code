    public class MyClass
    {
         // your existing code.... but make the members and constructor private.
    
    
         public static int Parse(string filenameToParse)
         {
             return new MyClass(filenameToParse).Parse();
         }
    }

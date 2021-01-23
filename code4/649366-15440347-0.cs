    public class MyClass
    {
       public MyClass(string aString, int anInt)
       {
         // Check for validity - throw exception if not valid
    
          ValidString = aString;
          ValidInt = anInt;
       }
    
       public string ValidString { get; private set; }
       public int ValidInt { get; private set; }
    }

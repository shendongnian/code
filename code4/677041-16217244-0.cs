    public class MyClass
    {
       class SubClass
       {
          int someValue;
       }
    
       private SubClass innerClass = new SubClass();
    
       public int SubValue
       {
          get { return innerClass.someValue; }
          set { innerClass.someValue = value; }
       }
    }

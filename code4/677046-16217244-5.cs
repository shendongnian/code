    public class WrapperClass
    {
       private SubClass1 internalClass1 = new internalClass1();
       private SubClass2 internalClass2 = new internalClass2();
    
       public int SubValue1
       {
          get { return internalClass1.someValue; }
          set { internalClass1.someValue = value; }
       }
    
       public int SubValue2
       {
          get { return internalClass2.someValue; }
          set { internalClass2.someValue = value; }
       }
    }
    
    internal class SubClass1
    {
       int someValue;
    }
    
    internal class SubClass2
    {
       int someValue;
    }

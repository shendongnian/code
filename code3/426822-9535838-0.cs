    public class MyClass
    {
     public int MyId { get; protected set; }
    }
    
    public class MyClass_Test
    {
     public int SetMyId
     {
      set { MyId = value; }
     }
    }

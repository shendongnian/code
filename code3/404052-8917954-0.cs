    public class MyClass
    {
       private readonly int MyProp { get; set; }
       public MyClass(int prop)
       {
           MyProp = prop; // cannot be modified further
       }
    }

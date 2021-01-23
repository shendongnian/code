    public class MyClass
    {
        public int MyId { get; protected set; }
    }
    
    public class MyClass_Test : MyClass
    {
        public int MyId_Set
        {
            set { MyId = value; }
        }
    }

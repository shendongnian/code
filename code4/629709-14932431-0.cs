    public abstract Test
    {
        public int Field1 {get;set;}
        public int Field2 {get;set,}
    }
    
    public class SomeTest : Test
    { 
        ...
    }
    
    [ServiceKnownType(typeof(SomeTest))]
    public class SomeService : ISomeService
    {
         public void SendTest(Test test)
    }

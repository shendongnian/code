    public interface ITest
    {
        SomeValue Id{ get;}
    }
    
    
    public class TestA : ITest
    {
        public SomeValue Id 
        {
           get {return TestA.StaicId; }
        }
        public static SomeValue StaticId
        {
             get {return "This is TestA";}
        }
    }
    if (someValue == TestA.StaticId)
           return new TestA();
  

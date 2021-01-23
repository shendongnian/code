    public interface ISomethingFactory {
      ISomething MakeSomething();
    }
        
    public sealed class SomethingFactory {
      public ISomething MakeSomething() {
        return new Something();
      }
    }
    
    class TestMe
    {
        private readonly ISomethingFactory _somethingFactory;
    
        public TestMe(ISomethingFactory somethingFactory) {
          _somethingFactory = somethingFactory;
        }
    
        public void DoSomething()
        {
            ISomething s = _somethingFactory.MakeSomething();
            int i = s.Run();
    
            //do things with i that I want to test
        }
    }

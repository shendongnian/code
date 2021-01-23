    public class TestMe 
    {
        public void DoSomething()
        {
            ISomething s = SomethingFactory();
            int i = s.Run();
            //do things with i that I want to test
        }
        protected virtual ISomething SomethingFactory()
        {
            return new Something();
        }
    }
    public interface ISomething
    {
        int Run();
    }
    public class Something : ISomething
    {
        public int Run()
        {
            return 1;
        }
    }

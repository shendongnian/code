    public interface ISomething
    {
    }
    
    public class SomethingA : ISomething
    {
    }
    
    public class SomethingB : ISomething
    {
    }
    
    public class Foo
    {
        public Foo(ISomething something)
        {
            Console.WriteLine(something);
        }
    }
    
    public class Bar
    {
        public Bar(ISomething something)
        {
            Console.WriteLine(something);
        }
    }

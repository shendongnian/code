    public interface IExample
    {
        void Do();
    }
    public abstract class DoFirst : IExample
    {
        public void Do()
        {
            Console.WriteLine("Doing it the first way");
        }
    }
    public abstract class DoSecond : IExample
    {
        public void Do()
        {
            Console.WriteLine("Doing it the second way");
        }
    }
    public class DoFirstConcrete : DoFirst, IExample
    {
        public void DoSomethingElse()
        {
            Do();
            Console.WriteLine("Doing something else also with first.");
        }
    }
    public class DoSecondConcrete : DoSecond, IExample
    {
        public void DoSomethingElse()
        {
            Do();
            Console.WriteLine("Doing something else also with second.");
        }
    }

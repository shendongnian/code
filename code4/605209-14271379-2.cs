    public interface IStrategy
    {
        void ExecuteLogic();
    };
    public class S1 : IStrategy
    {
        public void ExecuteLogic()
        {
            OneMethod();
        }
        void OneMethod()
        {
            Console.WriteLine("Hello");
        }
    };
    public class S2 : IStrategy
    {
        public void ExecuteLogic()
        {
            TotallyDifferentMethod();
        }
        void TotallyDifferentMethod()
        {
            Console.WriteLine("World");
        }
    };

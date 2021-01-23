    public interface IMyClass
    {
        void Do();
        void DoAgain();
    }
    public class MyClass : IMyClass 
    {
        [MyInterception]
        public void Do()
        {
            Console.WriteLine("Do!");
        }
        public void DoAgain()
        {
            Console.WriteLine("Do Again!");
        }
    }

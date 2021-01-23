    using Ninject;
    public class Program
    {
        static void Main(string[] args)
        {
            var kernel = new StandardKernel();
            var run = kernel.Get<MyClass>();
            run.DoWork();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting the app");
            IKernel kernel = new StandardKernel();
            kernel.Bind<IFoo>().ToConstant(new Foo());
            Console.WriteLine("Binding complete");
            kernel.Get<IFoo>();
            Console.WriteLine("Stopping the app");
        }
    }
    public interface IFoo
    {
    }
    public class Foo : IFoo
    {
        public Foo()
        {
            Console.WriteLine("Foo constructor called");
        }
    }

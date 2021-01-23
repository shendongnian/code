    class Program
    {
        public static void Main()
        {
            var classes = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.GetInterface("IFoo") != null);
            foreach(var foo in classes.Select(c => Activator.CreateInstance(c)).Cast<IFoo>())
            {
                foo.RequiredNonStaticMethod();
            }
        }
    }
    public interface IFoo
    {
        void RequiredNonStaticMethod();
    }
    public class FooImpl : IFoo
    {
        public void RequiredNonStaticMethod()
        {
            Console.WriteLine("Foo");
        }
    }

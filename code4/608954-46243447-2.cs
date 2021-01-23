    public class Program
    {
        static void Main()
        {
            UnityContainer container = new UnityContainer();
            var res = container.LoadConfiguration();
            Worker worker = res.Resolve<Worker>();
            Console.WriteLine(worker.DoOne());
            Console.WriteLine(worker.DoTwo());
            Console.Read();
        }
    }

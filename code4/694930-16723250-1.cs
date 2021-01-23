    class Program
    {
        static void Main(string[] args)
        {
            
            new Test().Go();
            Console.WriteLine("End: " + GC.GetTotalMemory(true));
            Console.ReadLine();
        }
    }
    
    public class Test
    {
        public void Go()
        {
            var anonObj = new { Name = "one" };
            Console.WriteLine(GC.GetTotalMemory(true));
        }
    }

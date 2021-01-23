    class Program
    {
        static void Main(string[] args)
        {
            decimal a = 22.58m;
            
            decimal rounded = Math.Floor(a/10m) * 10m;
            
            Console.WriteLine("{0:0.00}", rounded);
    
            Console.ReadLine();
        }
    }

    public class Default
    {
        public int Time1 { get; set; }
        public int Time2 { get; set; }
        public int Time3 { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Default d = new Default();
            Type t = d.GetType();
            
            foreach (var info in t.GetProperties())
            {
                //SET VALUE
                info.SetValue(d, 1);
            }
            foreach (var info in t.GetProperties())
            {
                //GET VALUE
                Console.WriteLine("Property: {0}", info.Name);
                Console.WriteLine("Value: {0}", info.GetValue(d));
            }
            //OR JUST ONE PROPERTY
            Console.WriteLine("Time1 Property Value: {0}", t.GetProperty("Time1").GetValue(d));
            Console.ReadLine();//PAUSE THE CONSOLE AFTER PROCESSING
        }
    }

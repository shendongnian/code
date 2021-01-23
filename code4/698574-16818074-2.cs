    class Program
    {
        static void Main(string[] args)
        {
           
            Console.WriteLine("saturnisko: {0}", Saturn.mass);
        }
    }
    public class Saturn
    {
        private static int masa = 0;
        public Saturn() {  }
        public static int mass
        {
            get { return masa; }
        }
    }  

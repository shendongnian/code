    class Program
    {
        static void Main(string[] args)
        {
            String str = "Kiran Bheemarti";
            List<byte> bytes = Encoding.ASCII.GetBytes(str).ToList();
            Console.Read();
        }
    }

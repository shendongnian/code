    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Moduleoutput()[0]);
            Console.ReadLine();
        }
        public static List<string> Moduleoutput()
        {
            List<string> output = new List<string>();
            output.Add("test 1");
            output.Add("test 2");
            output.Add("test 3");
            return output;
        }
    }

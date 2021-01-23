    public class Test
    {
        public static void Main()
        {
            Console.WriteLine("Current assembly : " + typeof(Test).Assembly.GetName().Version);
        }
    }

    public class Test
    {
        [DllImport("TestDll.dll")]
        public static extern string Crypter(string sIn);
        static void Main(string[] args)
        {
            Console.WriteLine(Crypter("a"));
        }
    }

    namespace ConsoleApplication10
    {
        class Program
        {
            static void Main(string[] args)
            {
                StringBuilder sb = new StringBuilder("abcdefg012345");
                sb.Insert(2, '-');
                sb.Insert(6, '-');
                
                Console.WriteLine(sb);
                Console.Read();
            }
        }
    }

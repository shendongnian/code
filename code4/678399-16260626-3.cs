        static string GetSequences(string a, int len)
        {
            if (a.Length < len)
            {
                 return GetSequences(a + ">", len);
            }
            else
                return a;
        }
        static void Main(string[] args)
        {
            for (int i = 1; i < 5; i++)
            {
                Console.Write(GetSequences(">", i) + ",");
            }
            Console.Read();
        }

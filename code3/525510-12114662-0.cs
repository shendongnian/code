        public static void Main()
        {
            string bigStr = GenString(100 * 1024 * 1024);
            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 0; i < 10; i++)
            {
                int counter = -1;
                StringBuilder sb = new StringBuilder();
                while (bigStr[++counter] != 'x')
                    sb.Append(bigStr[counter]);
                Console.WriteLine(sb.ToString().Length);
            }
            sw.Stop();
            Console.WriteLine("StringBuilder: {0}", sw.Elapsed.TotalSeconds);
            sw = Stopwatch.StartNew();
            for (int i = 0; i < 10; i++)
            {
                int counter = -1;
                while (bigStr[++counter] != 'x') ;
                Console.WriteLine(bigStr.Substring(0, counter).Length);
            }
            sw.Stop();
            Console.WriteLine("Substring: {0}", sw.Elapsed.TotalSeconds);
        }
        public static string GenString(int size)
        {
            StringBuilder sb = new StringBuilder(size);
            for (int i = 0; i < size - 1; i++)
            {
                sb.Append('a');
            }
            sb.Append('x');
            return sb.ToString();            
        }

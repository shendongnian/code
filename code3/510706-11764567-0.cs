        [MethodImplAttribute(MethodImplOptions.NoInlining)] 
        static string TrimEndMutiple(string str, string end)
        {
            int lenend = end.Length;
            int start = str.Length - lenend;
            while (String.CompareOrdinal(str, start, end, 0, lenend) == 0)
            {
                start -= lenend;
            }
            return str.Substring(0, start + lenend);
        } 
        static void Main(string[] args)
        {
            string s = "CharArray = { {}, {123}, {}, {3 3}, {111}, {}, {}";
            Regex reg = new Regex("(, {})+$", RegexOptions.Compiled);
            string s1 = reg.Replace(s, "");
            string s2 = TrimEndMutiple(s, ", {}");
            Stopwatch watch = new Stopwatch();
            int count = 1000 * 100;
            watch.Start();
            for (int i = 0; i < count; i++)
            {
                s1 = reg.Replace(s, "");
            }
            watch.Stop();
            Console.WriteLine("{0} {1,9:N3} ms", s1, watch.ElapsedTicks * 1000.0 / Stopwatch.Frequency);
            watch.Restart();
            for (int i = 0; i < count; i++)
            {
                s2 = TrimEndMutiple(s, ", {}"); 
            }
            watch.Stop();
            Console.WriteLine("{0} {1,9:N3} ms", s2, watch.ElapsedTicks * 1000.0 / Stopwatch.Frequency);
        }

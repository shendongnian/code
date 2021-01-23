    public static IEnumerable<string> SplitCSV(string strInput)
        {
            string[] str = strInput.Split(',');
            if (str == null)
                yield return null;
            StringBuilder quoteS = null;
            foreach (string s in str)
            {
                if (s.StartsWith("\""))
                {
                    if (s.EndsWith("\""))
                    {
                        yield return s;
                    }
                    quoteS = new StringBuilder(s);
                    continue;
                }
                if (quoteS != null)
                {
                    quoteS.Append($",{s}");
                    if (s.EndsWith("\""))
                    {
                        string s1 = quoteS.ToString();
                        quoteS = null;
                        yield return s1;
                    }
                    else
                        continue;
                }
                
                yield return s;
            }
        }
    static void Main(string[] args)
        {
            string s = "111,222,\"33,44,55\",666,\"77,88\",\"99\"";
            Console.WriteLine(s);
            var sp = SplitCSV(s);
            foreach (string s1 in sp)
            {
                Console.WriteLine(s1);
            }
            Console.ReadKey();
        }

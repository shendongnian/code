    class Program
    {
        private const string CHARS_TO_REPLACE = @"""/\[]:|<>+=;,?*'@";
        static void Main(string[] args)
        {
            var wc = new WebClient();
            var veryLargeString = wc.DownloadString("http://msdn.microsoft.com");
            using (var sr = new StringReader(veryLargeString))
            {
                var sb = new StringBuilder();
                int readVal;
                while ((readVal = sr.Read()) != -1)
                {
                    var c = (char)readVal;
                    if (!CHARS_TO_REPLACE.Contains(c))
                    {
                        sb.Append(c);
                    }
                }
                Console.WriteLine(sb.ToString());
            }
        }
    }

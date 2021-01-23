      static void Main(string[] args)
        {
            ReadFile();
        }
        private static void ReadFile()
        {
            StreamReader SR = new StreamReader(@"C:\Users\bharrison\Desktop\test.txt");
            Console.WriteLine("Reading file");
            while (!SR.EndOfStream)
            {
               string ReturnedValue = AnalyzeString(SR.ReadLine());
               Console.WriteLine(ReturnedValue);
            }
            Console.ReadLine();
        }
        private static string AnalyzeString(string line)
        {
            string TempLine = line;
            if (TempLine != null && TempLine != "")
            {
                if (TempLine.Contains("source"))
                {
                    return TempLine;
                }
                if (TempLine.Contains("MRU"))
                {
                    return TempLine;
                }
                if (TempLine.Contains("MRU Time"))
                {
                    return TempLine;
                }
            }
            else
            {
                return " ";
            }
            return " ";
        }

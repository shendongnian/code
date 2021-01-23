        static void Main(string[] args)
        {
            int numFiles = 30;
            for (int fileIndex = 0; fileIndex < numFiles; fileIndex++)
            {
                string randomFileName = Path.Combine(@"c:\temp", Path.GetRandomFileName() + ".csv");
                GenerateTestFile(randomFileName, 20, 10);
            }
        }
        static void GenerateTestFile(string fileName, int numLines, int numValues)
        {
            int[] values = new int[numValues];
            Random random = new Random(DateTime.Now.Millisecond);
            FileInfo f = new FileInfo(fileName);
            using (TextWriter fs = f.CreateText())
            {
                for (int lineIndex = 0; lineIndex < numLines; lineIndex++)
                {
                    for (int valIndex = 0; valIndex < values.Length; valIndex++)
                    {
                        values[valIndex] = random.Next(100);
                    }
                    fs.WriteLine(string.Join(",", values));
                }
            }
        }

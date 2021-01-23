        private static void Main(string[] args)
        {
            string cacheline = "";
            string line;
            System.IO.StreamReader file = new System.IO.StreamReader("C:\\overview2.srt");
            List<string> lines = new List<string>();
            while ((line = file.ReadLine()) != null)
            {
                if (line.Contains("medication"))
                {
                    lines.Add(cacheline);
                }
                cacheline = line;
            }
            file.Close();
            foreach (var l in lines)
            {
                Console.WriteLine(l);           
            }
        }

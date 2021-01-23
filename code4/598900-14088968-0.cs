        private static void Main(string[] args)
        {
            string cacheline = "";
            string line;
            System.IO.StreamReader file = new System.IO.StreamReader("C:\\overview2.srt");
            while ((line = file.ReadLine()) != null)
            {
                if (line.Contains("medication"))
                {
                    Console.WriteLine(cacheline);
                }
                cacheline = line;
            }
            file.Close();
        }

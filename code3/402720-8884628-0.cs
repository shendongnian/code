        static void Main(string[] args)
        {
            int linecount = 100;
            string path = @"C:\test\test.txt";
            Random rand = new Random();
            //Create File
            StreamWriter writer = new StreamWriter(path, false);
            for (int i = 0; i < linecount; i++)
            {
                for (int j = 0; j < rand.Next(10, 15); j++)
                {
                    writer.Write(rand.Next() + " ");
                }
                writer.WriteLine("");
            }
            writer.Close();
            //Sum File
            long sum = Enumerable.Sum<string>(
                (new StreamReader(path)).ReadToEnd().Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries),
                l => Enumerable.Max(
                    l.Split(' '),
                    i => String.IsNullOrEmpty(i.Trim()) ? 0 : long.Parse(i.Trim())
                    )
                );
        }

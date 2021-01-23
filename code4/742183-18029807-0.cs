        static void TxtToCSV(string s, TextWriter writer)
        {
            foreach (var line in s.Replace(", ", "").Split(new string[] { Environment.NewLine }, StringSplitOptions.None))
            {
                foreach (var t in line)
                {
                    writer.Write(t);
                }
                writer.WriteLine();
            }
            writer.Flush();
        }

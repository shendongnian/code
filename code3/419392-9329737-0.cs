            using (StreamWriter w = File.AppendText(@"testfile.txt"))
            {
                foreach (var line in sc)
                {
                    w.WriteLine(line);
                }
                w.Close();
            }

        private void extract_lines(string filein, string fileout)
        {
            using (StreamReader reader = new StreamReader(filein))
            {
                using (StreamWriter writer = new StreamWriter(fileout))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.Contains("what you looking for"))
                        {
                            writer.Write(line);
                        }
                    }
                }
            }
        }

            Regex replacer = new Regex("\b(?:is|are|am|could|will)\b");
            using (TextWriter writer = new StreamWriter("C:\\output.txt"))
            {
                using (StreamReader reader = new StreamReader("C:\\input.txt"))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        replacer.Replace(line, "");
                        writer.WriteLine(line);
                    }
                }
                writer.Flush();
            }

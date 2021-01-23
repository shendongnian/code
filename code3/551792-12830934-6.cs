            using (FileStream input = File.Open(args[0], FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (FileStream output = File.Create(args[1]))
            {
                using (StreamReader streamReader = new StreamReader(input))
                using (StreamWriter streamWriter = new StreamWriter(output))
                {
                    while (!streamReader.EndOfStream)
                    {
                        var line = streamReader.ReadLine();
                        var values = line.Split(',');
                        DateTime dt = new DateTime();
                        DateTime.TryParse(values[2], out dt);
                        values[2] = Convert.ToString(dt.Ticks);
                        streamWriter.WriteLine(string.Join(",", values));
                    }
                }
            }

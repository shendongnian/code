    using (var writer = new StreamWriter("output.txt"))
                {
                    foreach (var line in File.ReadAllLines("input.txt"))
                    {
                        writer.WriteLine(!line.StartsWith("<") ? string.Format("  -{0}", line) : line);
                    }
                }

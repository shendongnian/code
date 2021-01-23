                System.Text.StringBuilder builder = new System.Text.StringBuilder();
                using (FileStream stream = File.Open(args[0], FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (StreamReader streamReader = new StreamReader(stream))
                    {
                        while (!streamReader.EndOfStream)
                        {
                            var line = streamReader.ReadLine();
                            var values = line.Split(',');
                            DateTime dt = new DateTime();
                            DateTime.TryParse(values[2], out dt);
                            values[2] = Convert.ToString(dt.Ticks);
                            builder.AppendLine(string.Join(",", values));
                        }
                    }
                }
                File.WriteAllText(args[1], builder.ToString());

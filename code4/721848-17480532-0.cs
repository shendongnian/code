                Dictionary<string, List<string>> results = new Dictionary<string, List<string>>();
                results.Add("main", new List<string>());
                results.Add("extra", new List<string>());
                results.Add("side", new List<string>());
                string line;
                int count = -1;
                using (var reader = File.OpenText(@"C:\..\..\yourfile.txt"))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (!Regex.IsMatch(line, @"\d"))
                        {
                            count++;
                        }
                        else
                        {
                            results.ElementAt(count).Value.Add(line);
                        }
                    }
                   
                }

     // read file
                List<string> query = (from lines in File.ReadLines(this.Location.FullName, System.Text.Encoding.UTF8)
                                      select lines).ToList<string>();
    
                for (int i = 0; i < query.Count; i++)
                {
                    if (query[i].Contains("TextYouWant"))
                    {
                        i = i + 3;
                    }
                    else
                    {
                        continue;
                    }
                }

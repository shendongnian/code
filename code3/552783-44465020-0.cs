                    foreach (var line in File.ReadLines(pathToFile))
                    {
                        if (line.Contains("CustomerEN") && current == null)
                        {
                            current = new List<string>();
                            current.Add(line);
                        }
                        else if (line.Contains("CustomerEN") && current != null)
                        {
                            current.Add(line);
                        }
                    }
                    string s = String.Join(",", current);
                    MessageBox.Show(s);

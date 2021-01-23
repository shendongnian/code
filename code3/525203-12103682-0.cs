            List<string> sqls = File.ReadAllLines("Utils.txt")
                                    .Select(s =>
                                    {
                                        string temp = s.Substring(s.IndexOf("<"));
                                        return temp = temp.Substring(1, temp.IndexOf(">") - 1).Trim();
                                    })
                                    .ToList();

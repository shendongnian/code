            string regex = @"(?<sql>[\w]{1,}.sql)";
            List<string> sqls = File.ReadAllLines("Utils.txt")
                                    .Select(s =>
                                    {
                                        Match m = Regex.Match(s, regex);
                                        if (m.Success)
                                            return m.Groups["sql"].Value;
                                        else
                                            return string.Empty;
                                    })
                                    .ToList();

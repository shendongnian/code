    int result = -1;
                var matches = Regex.Matches(
                    HTMLText,
                    @"(?:\S+\s)?\S*page views\S*(?:\s\S+)?",
                    RegexOptions.IgnoreCase
                );
    
                foreach (Match m in matches)
                {
                    string val = m.Value;
                    int res=-1;
                    if (Int32.TryParse(val, out res))
                    {
                        result = res;
                        break;
                    }
                }

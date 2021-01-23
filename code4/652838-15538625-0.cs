    public string RemoveFromStart(string s, IEnumerable<string> strings )
            {
                foreach (var x in strings.Where(s.StartsWith))
                {
                    return s.Remove(0, x.Length);
                }
                return s;
            }

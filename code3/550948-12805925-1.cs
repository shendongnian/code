        public Boolean TryRegexMatchRemovedWhiteSpace(string input, string expr, out String matched)
        {
            
            Match m = Regex.Match(input, expr);
            if (m.Success)
            {
                StringBuilder r = new StringBuilder(m.Value.Length);
                foreach (var c in m.Value)
                {
                    if (!char.IsWhiteSpace(c))
                    {
                        r.Append(c);
                    }
                }
                matched = r.ToString();
            }
            else
            {
                matched = "";
            }
            return m.Success;
        }

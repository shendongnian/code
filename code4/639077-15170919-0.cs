    public static int Parse(this string phrase)
            {
                string num = string.Empty;
                foreach (char c in phrase.ToCharArray()) {
                    if (char.IsWhiteSpace(c)) { break; }
                    if (char.IsDigit(c)) { num += c.ToString(); }
                }
                return int.Parse(num);
            }

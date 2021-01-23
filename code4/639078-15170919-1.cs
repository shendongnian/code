     public static int Parse(this string phrase)
        {
            if (string.IsNullOrWhiteSpace(phrase)) { throw new NullReferenceException("phrase is null");}
            string num = string.Empty;
            foreach (char c in phrase.Trim().ToCharArray()) {
                if (char.IsWhiteSpace(c)) { break; }
                if (char.IsDigit(c)) { num += c.ToString(); }
            }
            return int.Parse(num);
        }

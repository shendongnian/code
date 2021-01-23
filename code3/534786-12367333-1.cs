        public static string EscapeNonCharAndNonDigitSymbols(this string str)
        {
            if (str == null)
                throw new NullReferenceException();
            var chars = new List<char>(str.ToCharArray());
            for (int i = str.Length-1; i>=0; i--)
            {
                if (!Char.IsLetterOrDigit(chars[i]))
                    chars.RemoveAt(i);
            }
            return new String(chars.ToArray());
        }

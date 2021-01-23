    public static class StringExtendsionsMethods
    {
        public static int IndexOfUsingBoundary(this String s, String word)
        {
            var firstLetter = word[0].ToString();
            StringBuilder sb = new StringBuilder();
            bool previousWasLetterOrDigit = false;
            int i = 0;
            while (i < s.Length - word.Length + 1)
            {
                bool wordFound = false;
                char c = s[i];
                if (c.ToString().Equals(firstLetter, StringComparison.CurrentCultureIgnoreCase))
                    if (!previousWasLetterOrDigit)
                        if (s.Substring(i, word.Length).Equals(word, StringComparison.CurrentCultureIgnoreCase))
                        {
                            wordFound = true;
                            bool wholeWordFound = true;
                            if (s.Length > i + word.Length)
                            {
                                if (Char.IsLetterOrDigit(s[i + word.Length]))
                                    wholeWordFound = false;
                            }
                            if (wholeWordFound)
                                return i;
                            sb.Append(word);
                            i += word.Length;
                        }
                if (!wordFound)
                {
                    previousWasLetterOrDigit = Char.IsLetterOrDigit(c);
                    sb.Append(c);
                    i++;
                }
            }
            return -1;
        }
    }

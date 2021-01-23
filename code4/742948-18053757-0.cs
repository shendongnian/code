    public static class StringExtendsionsMethods
    {
        public static String ReplaceWholeWord(this String s, String word, String bywhat)
        {
            char firstLetter = word[0];
            StringBuilder sb = new StringBuilder();
            bool previousWasLetterOrDigit = false;
            int i = 0;
            while (i < s.Length - word.Length + 1)
            {
                bool wordFound = false;
                char c = s[i];
                if (c == firstLetter)
                    if (!previousWasLetterOrDigit)
                        if (s.Substring(i, word.Length).Equals(word))
                        {
                            wordFound = true;
                            bool wholeWordFound = true;
                            if (s.Length > i + word.Length)
                            {
                                if (Char.IsLetterOrDigit(s[i + word.Length]))
                                    wholeWordFound = false;
                            }
    
                            if (wholeWordFound)
                                sb.Append(bywhat);
                            else
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
    
            if (s.Length - i > 0)
                sb.Append(s.Substring(i));
    
            return sb.ToString();
        }
    }

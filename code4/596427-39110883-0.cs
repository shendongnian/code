        public static string ReverseWords(string s)
        {
            if (string.IsNullOrEmpty(s))
                return s;
            char[] chars = s.ToCharArray();
            int wordStartIndex = -1;
            for (int i = 0; i < chars.Length; i++)
            {
                if (!Char.IsWhiteSpace(chars[i]) && wordStartIndex < 0)
                {
                    // Remember word start index
                    wordStartIndex = i;
                }
                else
                if (wordStartIndex >= 0 && (i == chars.Length-1 || Char.IsWhiteSpace(chars[i + 1]))) {
                    // End of word detected, reverse the chacacters in the word range
                    ReverseRange(chars, wordStartIndex, i);
                    // The current word is complete, reset the start index  
                    wordStartIndex = -1;
                }
            }
            // Reverse all chars in the string
            ReverseRange(chars, 0, chars.Length - 1);
            return new string(chars);
        }
        // Helper
        private static void ReverseRange(char[] chars, int startIndex, int endIndex)
        {
            for(int i = 0; i <= (endIndex - startIndex) / 2; i++)
            {
                char tmp = chars[startIndex + i];
                chars[startIndex + i] = chars[endIndex - i];
                chars[endIndex - i] = tmp;
            }            
        }

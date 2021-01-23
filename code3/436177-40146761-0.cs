    public static bool IsPalindrome(string word)
        {
            string spare = word;
            string reversal = null;
            while (word.Length > 0)
            {
                reversal = string.Concat(reversal, word.LastOrDefault());
                word = word.Remove(word.Length - 1);
            }
            return spare.Equals(reversal);
        }

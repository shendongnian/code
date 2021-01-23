        string test = "Paul";
        test = ReplaceAtIndex(0, 'M', test);
        (...)
        static string ReplaceAtIndex(int i, char value, string word)
        {
            char[] letters = word.ToCharArray();
            letters[i] = value;
            return string.Join("", letters);
        }

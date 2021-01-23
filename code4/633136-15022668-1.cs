    class Program
    {
        enum LetterConversion
        {
            ToLower,
            ToUpper,
            None
        }
        private static Dictionary<Char, int> 
            GetChars(string input, LetterConversion conversion)
        {
            switch (conversion)
            {
                case LetterConversion.ToLower:
                    input = input.ToLower();
                    break;
                case LetterConversion.ToUpper:
                    input = input.ToUpper();
                    break;
            }
            return input.GroupBy(ch => ch)
            .ToDictionary(g => g.Key, g => (int)g.Key);
        }
        static void Main(string[] args)
        {
            // the values will be 97, 98, 99
            var d1 = GetChars("abcA", LetterConversion.ToLower);
            // the values will be 65, 66, 67
            var d2 = GetChars("abcA", LetterConversion.ToUpper);
            // the values will be 97, 98, 99, 65
            var d3 = GetChars("abcA", LetterConversion.None);
        }
    }

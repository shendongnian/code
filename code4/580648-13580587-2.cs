    public static class TelephoneFinder
    {
        static char[] firstDigits = new char[]
                       { '0', '1', 'A', 'D', 'G', 'J', 'M', 'P', 'T', 'W' };
        public static string First(string number)
        {
            char[] firstWord = new char[number.Length];
            for (int i = 0; i < number.Length; i++)
            {
                var c = number.Substring(i, 1);
                firstWord[i] = firstDigits[int.Parse(c)];
            }
            return new String(firstWord);
        }
        static Dictionary<char, char> rollovers = new Dictionary<char, char> { 
            { '1', '0' }, { '2', '1' }, { 'D', 'A' }, { 'G', 'D' }, { 'J', 'G' },
            { 'M', 'J' }, { 'P', 'M' }, { 'T', 'P' }, { 'W', 'T' }, { '[', 'W' } };
        public static string Next(string current)
        {
            char[] chars = current.ToCharArray();
            for (int i = chars.Length - 1; i >= 0; i--)
            {
                // Increment current character
                chars[i] = (char)((int)chars[i] + 1);
                if (rollovers.ContainsKey(chars[i]))
                    // Roll current character over
                    // Will then continue on to next character
                    chars[i] = rollovers[chars[i]];
                else
                    // Finish loop with current string
                    return new String(chars);
            }
            // Rolled everything over - end of list of words
            return null;
        }
    }

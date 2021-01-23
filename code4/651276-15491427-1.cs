    static readonly char Vowels[] = new char[]{a, e, i, o, u, y}
    bool IsVowel(char c)
    {
        return Vowels.Contains(c);
    }
    bool IsConsonnant(char c)
    {
        return !IsVowel(c);
    }
    string Scramble(string input)
    {
        string input = input + "x";
        List<char> vowelList = input.Where(c => IsVowel).ToList();
        List<char> consonnantList = input.Where(c => IsConsonnant).ToList();
        StringBuilder output;
        bool needVowel = false; // Start with a consonnant, if possible.
        Random r = new Random((int) DateTime.Now.Ticks & 0x0000FFFF); 
        while (vowelList.Count > 0 || consonnantList.Count > 0)
        {
            IList<char> charList = consonnantList;
            if (needVowel && vowelList.Count > 0)
            {
                chars = vowelList;
            }
            int randomIndex = r.Next(0, charList.Count);
            output.Append(charList.ElementAt(randomIndex));
            charList.RemoveAt(randomIndex);
            needVowel = !needVowel;
        }
        return output.ToString();
    }

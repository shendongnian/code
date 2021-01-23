    public int NumberOfVowels(string s)
    {
        const string vowels = "aeiouAEIOU";
        int n = 0;
        for (int i = 0; i < s.Length; i++) {
            if (vowels.Contains(s[i])) {
                n++;
            }
        }
        return n;
    }

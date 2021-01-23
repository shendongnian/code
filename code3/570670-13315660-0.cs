    # Untested code!
    int FindPattern(string input, string output, string[] patterns)
    {
        for (int i = 0; i < patterns.Length; i++)
        {
            if (ApplyPattern(input, patterns[i]) == output)
            {
                return i;
            }
        }
        return -1;
    }

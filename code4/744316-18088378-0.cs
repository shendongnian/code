    private List<string> Generate(int start, int end, bool allowDupes)
    {
        var strings = new HashSet<string>();
        var list = new List<string>();
        var generator = new StringGenerator(LowerCase, UpperCase, Digits, NumberOfCharacters);
        for (var i = start; i < end; i++)
        {
            while (true)
            {
                string randomString = GetRandomString();
                if (allowDupes == false && strings.Add(randomString))
                {
                    continue;
                }
                break;
            }
            GeneratedStringCount = i + 1;
        }
        return new List<string>(list);
    }
    private string GetRandomString()
    {
        StringBuilder sb = new StringBuilder();
        for (var j = 0; j < NumberOfSegments; j++)
        {
            sb.Append(generator.GenerateRandomString());
            if (j < NumberOfSegments - 1)
            {
                sb.Append(Delimiter);
            }
        }
    }

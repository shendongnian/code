    static string Concatenate(string[] strings, int maxLength, string separator)
    {
        var totalLength = strings.Sum(s => s.Length);
        var requiredLength = totalLength - (strings.Length - 1)*separator.Length;
        // Return if there is enough place.
        if (requiredLength <= maxLength)
            return String.Concat(strings.Take(strings.Length - 1).Select(s => s + separator).Concat(new[] {strings.Last()}));
        // The problem...
        var helpers = new ConcatenateInternal[strings.Length];
        for (var i = 0; i < helpers.Length; i++)
            helpers[i] = new ConcatenateInternal(strings[i].Length);
        var avaliableLength = maxLength - (strings.Length - 1)*separator.Length;
        var charsInserted = 0;
        var currentIndex = 0;
        while (charsInserted != avaliableLength)
        {
            for (var i = 0; i < strings.Length; i++)
            {
                if (charsInserted == avaliableLength)
                    break;
                if (currentIndex >= strings[i].Length)
                {
                    helpers[i].Finished = true;
                    continue;
                }
                helpers[i].StringBuilder.Append(strings[i][currentIndex]);
                charsInserted++;
            }
            currentIndex++;
        }
        var unified = new StringBuilder(avaliableLength);
        for (var i = 0; i < strings.Length; i++)
        {
            if (!helpers[i].Finished)
            {
                unified.Append(helpers[i].StringBuilder.ToString(0, helpers[i].StringBuilder.Length - 3));
                unified.Append("...");
            }
            else
            {
                unified.Append(helpers[i].StringBuilder.ToString());
            }
            if (i < strings.Length - 1)
            {
                unified.Append(separator);
            }
        }
        return unified.ToString();
    }

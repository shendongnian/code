    public static List<string> GetStringSegments(string original, int linesPerSegment)
    {
        List<string> segments = new List<string>();
        
        int startIndex = 0;
        int newLinesEncountered = 0;
        
        for (int i = 0; i < original.Length; i++)
        {
            if (original[i] == '\n')
            {
                newLinesEncountered++;
            }
            if (newLinesEncountered == linesPerSegment
                || i == original.Length - 1)
            {
                segments.Add(original.Substring(startIndex, (i - startIndex + 1)));
                startIndex = i + 1;
                newLinesEncountered = 0;
            }
        }
        return segments;
    }

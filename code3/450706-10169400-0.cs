    public static List<string> GetStringSegments(string originalString, int linesPerSegment)
    {
        
        string[] allLines = originalString.Split(new string[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries); 
        StringBuilder sb = new StringBuilder();
        
        int linesProcessed = 0;
        for (int i = 0; i < allLines.Length; i++)
        {
            sb.AppendLine(allLines[i]);
            linesProcessed++;
            if (linesProcessed == linesPerSegment
                || i == allLines.Length-1)
            {
                segs.Add(sb.ToString());
                sb.Clear();
                inesProcessed = 0;
            }
        }
    }

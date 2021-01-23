    /// <returns><c>true</c> if the header tail was present</returns>
    public bool FixedToCsv(string fullFile, string tail)
    {
        var hadTail = false;
        var lines = File.ReadAllLines(fullFile);
        var firstLine = lines.First();
        if (firstLine.EndsWith(tail)
        {
            hadTail = true;
            firstLine = firstLine.SubString(0, firstLine.Length - tail.Length);
        }
        var widths = new List<KeyValuePair<int, int>>();
        var innerCounter = 0;
        var outerCounter = 0
        var firstLineChars = firstLine.ToCharArray();
        var lastChar = firstLineChars[0]; 
        foreach(var c in firstLineChars)
        {
            if (c == lastChar)
            {
                innerCounter++;
            }
            else
            {
                widths.Add(KeyValuePair<int, int>(
                    outerCounter
                    innerCounter);
                innerCounter = 0;
                lastChar = c;
            }
            outerCounter++;
        }
        var csvLines = lines.Select(line => string.Join(",",
            widths.Select(pair => line.Substring(pair.Key, pair.Value))));
        //Get filePath and fileName from fullFile here.
        File.WriteAllLines(filePath + "\\" + fileName + ".csv", csvLines);
        return hadTail;
    }

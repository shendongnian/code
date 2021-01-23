    public void FixedToCsv(string fullFile)
    {
        var lines = File.ReadAllLines(fullFile);
        var firstLine = lines.First();
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
                widths.Add(new KeyValuePair<int, int>(
                    outerCounter
                    innerCounter);
                innerCounter = 0;
                lastChar = c;
            }
            outerCounter++;
        }
        var csvLines = lines.Select(line => string.Join(",",
            widths.Select(pair => line.Substring(pair.Key, pair.Value))));
        // Get filePath and fileName from fullFile here.
        File.WriteAllLines(filePath + "\\" + fileName + ".csv", csvLines);
    }

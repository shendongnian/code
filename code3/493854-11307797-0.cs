    string[] previousLines = new string[3];
    int index = 0;
    string line;
    while ((line = reader.ReadLine()) != null)
    {
        if (previousLines[index] != null)
        {
            sw.WriteLine(previousLines[index]);
        }
        line = line.Replace("|", "")
                   .Replace("MY30", "")
                   .Replace("E", "");
        line = Regex.Replace(line, @"\s{2,}", " ");
        previousLines[index] = line;
        index = (index + 1) % previousLines.Length;
    }

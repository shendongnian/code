    List<string> Normalize(string fileName, int size)
    {
        List<string> result = new List<string>();
        int blanks = 0;
        foreach (var line in File.ReadAllLines(fileName))
        {
            if (line.Trim() == "")
            {
                if (blanks++ < size)
                    result.Add("");
            }
            else
            {
                blanks = 0;
                results.Add(line);
            }
        }
        return line;
    }
            

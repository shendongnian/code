    private static int GetNumber(string fileName)
    {
        string line;
        string key = "GeneratedNumber=\"";
        using (StreamReader file = new StreamReader(fileName))
        {
            while ((line = file.ReadLine()) != null)
            {
                if (line.Contains(key))
                {
                    int startIndex = line.IndexOf(key) + key.Length;
                    int endIndex = line.IndexOf("\"", startIndex);
                    return int.Parse(line.Substring(startIndex, endIndex));
                }
            }
        }
    
        return 0;
    }

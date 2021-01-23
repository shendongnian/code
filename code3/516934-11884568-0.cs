    private void setValue(string filePath, string key, string value)
    {
        string[] lines= File.ReadAllLines(filePath);
        for(int x = 0; x < lines.Length; x++)
        {
            string[] fields = lines[x].Split(':');
            if (fields[0].TrimEnd() == key)
            {
                lines[x] = fields[0] + ':' + value;
                File.WriteAllLines(lines);
                break;
            }
        }
    }

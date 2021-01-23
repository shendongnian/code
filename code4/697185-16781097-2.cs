    public bool isFixedWidth (string fileName)
    {
        string[] lines = File.ReadAllLines(fileName);
        int length = lines[0].Length;
        foreach (string s in lines)
        {
            if (s.length != Length)
            {
                return false;
            }
        }
        return true;
    }

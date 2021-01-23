    private IEnumerable<string> GetAllLines(string path)
    {
        using (StreamReader streamReader = new StreamReader(path))
        {
            while (!streamReader.EndOfStream)
            {
                yield return streamReader.ReadLine();
            } 
        }
    }

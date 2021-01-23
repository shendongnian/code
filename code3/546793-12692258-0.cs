    public static IEnumerable<IEnumerable<string>> Partitian(IEnumerable<string> source)
    {
        List<string> buffer = new List<string>();
        int? lastRef = null;
    
        int position = 0;
        foreach (string s in source)
        {
            if (s == "REF")
                lastRef = position;
            else if (s == "IT1" && lastRef.HasValue)
            {
                yield return buffer.Take(lastRef.Value + 1);
                buffer.Clear();
                position = 0;
                lastRef = null;
            }
            buffer.Add(s);
    
            position++;
        }
    
        if (buffer.Any() && lastRef.HasValue)
            yield return buffer;
    }

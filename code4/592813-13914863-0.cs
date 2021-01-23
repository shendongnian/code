    long count = 0;
    using (StreamReader r = new StreamReader(f))
    {
        string line;
        while ((line = r.ReadLine()) != null)
        {
            count++;
        }
    }
    
    return count;

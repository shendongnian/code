    Dictionary<string, string> pairs = new Dictionary<string, string>();
    for (int ii = 0; ii < values.Length; ++ii)
    {
        // empty values are skipped
        if (values[ii].Length == 0) continue;
        
        string value = values[ii + 1].Trim()
                                     .TrimEnd(','); // remove any trailing commas
    
        pairs.Add(values[ii], value.TrimEnd());
        ii++; // use two each time
    }

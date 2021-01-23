    foreach (string line in lines)
    {
        if (line.Length < 10)
            continue;
        string a = line.Remove(0, 10);
        ...
    }

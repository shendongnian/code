    for (int i = 0; i < lines.Count; i++)
    {
        if (r.IsMatch(lines[i]))
        {
            Console.WriteLine(i);//Do the index-based task instead...
        }
    }

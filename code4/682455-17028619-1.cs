    for (int i = 0; i < line.Length; i++)
    {
        if (line[i].Contains("INFO"))
        {
            string l = Regex.Replace(line[i], @"\p{Zs}{2,}|\t+", "_");
            string[] sublines = l.Split('_');
            // If you want to see the debug....
            sublines.ForEach(s => Debug.Log(s));
        }
    }

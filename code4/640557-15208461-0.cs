     for (int i = 0; i < lines.Length; i++)
    {
        try
        {
            string[] matches = r.Split(lines[i]);
            if (matches[1].Equals("GoTo"))
            {
                i = matches[2] - 1; // -1 because for loop will do i++
            }
        }
        catch (Exception)
        {
        }
    }

    List<string> lines = new List<string>();
    foreach (var line in File.ReadLines("filename"))
    {
        if (line[0] == '>')
        {
            if (lines.Count > 0)
            {
                // write contents of lines list to file.
                // and clear the list.
                lines.Clear();
            }
        }
        lines.Add(line);
    }
    // here, do the last part
    if (lines.Count > 0)
    {
        // write contents of lines list to file.
    }

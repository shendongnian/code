    var found = false;
    string file;
    foreach (file in Directory.EnumerateFiles(
                "d:\\tes\\",
                "*.txt",
                SearchOption.AllDirectories))
    {
        foreach(var line in File.ReadLines(file))
        {
            if (line.Contains(searchString))
            {
                found = ture;
                break;
            }
        }
        if (found)
        {
                break;
        }
    }
    if (found)
    {
        var message = string.Format("Search string found in \"{0}\".", file)
        MessageBox.Show(file);
    }

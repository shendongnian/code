    var found = false;
    string file;
    foreach (file in Directory.EnumerateFiles(
                "d:\\tes\\",
                "*.txt",
                SearchOption.AllDirectories))
    {
        using (var reader = new StreamReader(file))
        {
            var line = reader.ReadLine();
            while (line != null)
            {
                if (line.Contains(searchString))
                {
                   found = ture;
                   break;
                }
                line = reader.ReadLine();
            }
            if (found)
            {
                break;
            }
        }
    }
    if (found)
    {
        var message = string.Format("Search string found in \"{0}\".", file)
        MessageBox.Show(file);
    }

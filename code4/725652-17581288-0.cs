    foreach (var line in File.ReadLines(@"c:\test.txt"))
    {
        string trimmed = line.Trim();
        int pos = trimmed.IndexOf('=');
        if (pos == -1) continue;
        string category = trimmed.Substring(0, pos);
        string content = trimmed.Substring(pos+1);
        switch (category)
        {
            case "Subject":
                // do stuff
                break;
            case "From":
                // do stuff
                break;
            // etc.
        }
    }

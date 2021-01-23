    var lines = File.ReadAllLins(file);
    for (int i = 0; i < lines.Length; i++)
    {
        if (lines[i].StartsWith("\"homepage\": "))
        {
            lines[i] = "\"homepage\": \"http://www.MyWebsite.com\"",";
        }
    }
    File.WriteAllLines(file, lines);

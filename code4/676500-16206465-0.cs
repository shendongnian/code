        string file = "TextFile1.txt";
        List<string> lines = new List<string>();
        using (StreamReader r = new StreamReader(f))
        {
            string line;
            while ((line = r.ReadLine()) != null && !line.StartsWith("*"))
            {
                lines.Add(line);
            }
        }

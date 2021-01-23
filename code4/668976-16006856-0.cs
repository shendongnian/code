    private void Parse()
    {
        var Dictionary = new List<List<string>>();
        var Section = new List<string>();
        using (var sr = new StreamReader(this.fileName))
        {
            while (sr.Peek() > -1) 
            {
                var line = sr.ReadLine().Trim();
                if (line.StartsWith("SECTION") && Section.Count > 0)
                {
                    Dictionary.Add(Section); //// Store previous section
                    Section = new List<string>();
                }
                if (line.StartsWith("VALUE"))
                {
                    line = line.Remove(0, line.IndexOf(' '));
                    Section.Add(line.Trim());
                }
            }
            if (Section.Count > 0)
            {
                Dictionary.Add(Section); //// Store last section
            }
        }
    }

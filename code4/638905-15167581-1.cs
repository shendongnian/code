    var entries = new List<Entry>();
    using (var fStream = File.OpenRead(fileLocation))
    using (var reader = new StreamReader(fStream))
    {
        while (!reader.EOF)
        {
            var line = reader.ReadLine();
            // assuming tab as the delimiter, replace with whatever you're using
            var parts = line.Split('\t');
            if (parts.Length != 4)
            {
                // whatever you need to do for error handling
                // using could throw an error or just skip to the next line
                continue;
            }
       
            entries.Add(
                new Entry
                {
                    // ideally you'd use int.TryParse to provide further error handling
                    Column1 = int.Parse(parts[0]),
                    Column2 = int.Parse(parts[1]),
                    Column3 = int.Parse(parts[2]),
                    Column4 = int.Parse(parts[4])
                }
            );
        }
    }

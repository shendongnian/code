        // Parse the file
        var indexes = new List<long>();
        using (var fs = File.OpenRead("text.txt"))
        {
            indexes.Add(fs.Position);
            int chr;
            while ((chr = fs.ReadByte()) != -1)
            {
                if (chr == '\n')
                {                        
                    indexes.Add(fs.Position);
                }
            }
        }
        int lineCount = indexes.Count;
        int randLineNum = new Random().Next(0, lineCount - 1);
        string lineContent = "";
        // Read the random line
        using (var fs = File.OpenRead("text.txt"))
        {
            fs.Position = indexes[randLineNum];
            using (var sr = new StreamReader(fs))
            {
                lineContent = sr.ReadLine();
            }
        }

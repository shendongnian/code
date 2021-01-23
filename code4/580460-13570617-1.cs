    using (StreamWriter SW = new StreamWriter(newFile))
    {
        using (StreamReader sr = new StreamReader(sourceFilePath))
        {
            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();
                if (line.Contains(stringToSearch))
                    SW.WriteLine(line);
            }
        }
    }

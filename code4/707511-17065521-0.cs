    var writers = new Dictionary<string, StreamWriter>();
    using (StreamReader sr = new StreamReader(pathToFile)) 
    {
        while (sr.Peek() >= 0) 
        {
            var line = sr.ReadLine();
            var key = line.Split(new[]{ ',' },2)[0];
            if (!lineGroups.ContainsKey(key))
            {
                writers[key] = new StreamWriter(GetPathToOutput(key));
            }
            writers[key].WriteLine(line);
        }
    }
    foreach(StreamWriter sw in writers)
    {
        sw.Dispose();
    }

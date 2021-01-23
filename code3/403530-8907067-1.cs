    static void Main()
    {
        foreach(var part in ReadParts("Raw.txt"))
        {   // all the fields for the part are available; I'm just showing
            // one of them for illustration
            Console.WriteLine(part["ID"]);
        }
    }
    static IEnumerable<IDictionary<string,string>> ReadParts(string path)
    {
        using(var reader = File.OpenText(path))
        {
            var current = new Dictionary<string, string>();
            string line;
            while((line = reader.ReadLine()) != null)
            {
                if(string.IsNullOrWhiteSpace(line)) continue;
                if(line.StartsWith("ENDCARD:"))
                {
                    yield return current;
                    current = new Dictionary<string, string>();
                } else
                {
                    var parts = line.Split(':');
                    current[parts[0].Trim()] = parts[1].Trim().TrimEnd(';');
                }
            }
            if (current.Count > 0) yield return current;
        }
    }

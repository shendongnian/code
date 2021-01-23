    private string GetType(string file)
    {
        string type = string.Empty;
        var request = XDocument.Load(file);
        var get_command = from r in request.Descendants("Transaction")
                          select new
                          {
                              Type = r.Element("Type").Value
                          };
        foreach (var c in get_command)
        {
            type = c.Type;
        }
        return type;
    }

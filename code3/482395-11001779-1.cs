    var inserts = File.ReadLines(path)
             .Where(l => l.IndexOf("VALUES (") > -1)
             .Select(l => new
             {
                 SQL = l,
                 Params = l.Substring(l.IndexOf("VALUES (") + 8)
                           .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
             });
    foreach (var insert in inserts)
    {
        String sql = insert.SQL;
        String[] parameter = insert.Params;
    }

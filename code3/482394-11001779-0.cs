    var lines = File.ReadLines(path);
    var lineInfos =
        lines.Where(l => l.IndexOf("VALUES (") > -1)
             .Select(l => new
             {
                 SQL = l,
                 Values = l.Substring(l.IndexOf("VALUES (") + 8)
                           .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
             });
    foreach (var li in lineInfos)
    {
        String sql = li.SQL;
        String[] values = li.Values;
    }

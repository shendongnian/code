    var matches = lines.Select(line => regex.Match(line));
    var dataTable = new DataTable();
    foreach (var columnName in new[] { "A", "B", "C", "D" })
      dataTable.Columns.Add(columnName);
    foreach (var match in matches)
      dataTable.Rows.Add(
        match.Groups.Cast<Group>().Skip(1).Select(group => group.Value).ToArray()
      );
    dataTable.Dump();

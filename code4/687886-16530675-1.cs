    var lines = File.ReadAllLines("test.csv");
    DataTable dt = new DataTable();
    var columNames = lines[0].Split(new char[] { ',' });
    for (int i = 0; i < columNames.Length; i++)
    {
        dt.Columns.Add(columNames[i]);
    }
    for (int i = 1; i < lines.Length; i++)
    {
        dt.Rows.Add(lines[i].Split(new char[] { ',' }));
    }
    var rows = dt.Rows.Cast<DataRow>();
    var result = rows.OrderBy(i => i["In_time"])
        .ThenBy(i => i["In_Location"]);
    // sum
    var sum = rows.Sum(i => Int32.Parse(i["AgentID"].ToString()));

    DataTable dt = new DataTable();
    var lines = File.ReadAllLines(strPath).ToList();
    dt.Columns.AddRange(lines.First().Split(new char[] { '\t' }).Select(col => new DataColumn(col)).ToArray());
    lines.RemoveAt(0);
    lines.Select(x => x.Split(new char[] { '\t' })).ToList().ForEach(row => dt.Rows.Add(row));

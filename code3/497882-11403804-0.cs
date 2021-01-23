    if (listView1 == null)
        throw new Exception("listView1 is null");
    if (listView1.Columns == null)
        throw new Exception("Columns is null");
    if (listView1.Columns.Length < 3)
        throw new Exception("Columns length is out of range");

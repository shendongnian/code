    var dtA = new DataTable();
    dtA.Columns.Add("A");
    dtA.Columns.Add("B");
    dtA.Columns.Add("C");
    var dtB = new DataTable();
    dtB.Columns.Add("D");
    dtB.Columns.Add("E");
    dtB.Columns.Add("F");
    dtA.Merge(dtB);

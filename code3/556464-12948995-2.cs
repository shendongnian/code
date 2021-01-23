    DataTable table1 = new DataTable("table1");
    table1.Columns.Add("ID", typeof(int));
    table1.Columns.Add("Name", typeof(String));
    object[] a1 = { 1, "T1Row1Name" };
    object[] a2 = { 2, "T1Row2Name" };
    object[] a3 = { 3, "T1Row3Name" };
    object[] a4 = { 4, "T1Row4Name" };
    table1.Rows.Add(a1);
    table1.Rows.Add(a2);
    table1.Rows.Add(a3);
    table1.Rows.Add(a4);
    DataTable table2 = new DataTable("table2");
    table2.Columns.Add("ID", typeof(int));
    table2.Columns.Add("Name", typeof(String));
    table2.Columns.Add("Table1ID", typeof(int));
    object[] b1 = { 1, "T2Row1Name", 1 };
    object[] b2 = { 2, "T2Row2Name", 2 };
    object[] b3 = { 3, "T2Row3Name", 2 };
    object[] b4 = { 4, "T2Row4Name", 2 };
    object[] b5 = { 5, "T2Row5Name", 3 };
    table2.Rows.Add(b1);
    table2.Rows.Add(b2);
    table2.Rows.Add(b3);
    table2.Rows.Add(b4);
    table2.Rows.Add(b5);
    var joinedTable = InnerJoin(table1, table2, table1.Columns["ID"], table2.Columns["Table1ID"]);
    foreach (DataRow r in joinedTable.Rows)
    {
        DataRow r1 = r.Field<DataRow>("Row1");
        DataRow r2 = r.Field<DataRow>("Row2");
        String r1Name = r1.Field<String>("Name");
        String r2Name = r2.Field<String>("Name");
    }

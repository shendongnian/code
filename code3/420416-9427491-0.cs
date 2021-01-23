    // create and fill table
    DataTable table = new DataTable();
    table.Columns.Add("Id", typeof(int));
    table.Rows.Add(new object[]{1});
    table.Rows.Add(new object[]{2});
    table.Rows.Add(new object[]{3});
    // create a wrapper around Rows
    LinqList<DataRow> rows = new LinqList<DataRow>(table.Rows);
    // do a simple select
    IEnumerable<DataRow> selectedRows = from r in rows
           where (int)r["Id"] == 2
           select r;
    // output result
    foreach (DataRow row in selectedRows)
      Console.WriteLine(row["Id"]);
 

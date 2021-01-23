bool tf;
// Unbelievable...
DataRowComparer<DataRow> drc = DataRowComparer.Default;
DataTable tbl;
tbl = new DataTable();
tbl.Columns.Add("One", typeof(string));
tbl.Columns.Add("Two", typeof(string));
tbl.Columns.Add("Three", typeof(string));
tbl.Rows.Add("One", "Two", "Three");
tbl.Rows.Add("One", "Two", "Three");
tbl.Rows.Add("One", "Three", "Two");
tbl.Rows.Add("One", "Two");
tbl.Rows.Add("One", "Two");
tf = dc.Equals(tbl.Rows[0], tbl.Rows[1]);
tf = dc.Equals(tbl.Rows[0], tbl.Rows[2]);
tbl2 = new DataTable();
tbl2.Columns.Add("One", typeof(string));
tbl2.Columns.Add("Two", typeof(string));
tbl2.Columns.Add("Nine", typeof(string));  // Diff col name
tbl2.Rows.Add("One", "Two", "Three");
tbl2.Rows.Add("One", "Two", "Three");
tbl2.Rows.Add("One", "Three", "Two");
tbl2.Rows.Add("One", "Two");
tbl2.Rows.Add("One", "Two");
tf = dc.Equals(tbl.Rows[0], tbl2.Rows[0]);
tf = dc.Equals(tbl.Rows[1], tbl2.Rows[1]);
tf = dc.Equals(tbl.Rows[0], tbl2.Rows[1]);
tf = dc.Equals(tbl.Rows[0], tbl2.Rows[2]);
But I like this just as well as jacking around with the DataRowComparer instantiation - I'd need to see be a performance advantage.
tbl.Rows[0].ItemArray.SequenceEquals(tbl.Rows[1]);
  [1]: https://docs.microsoft.com/en-us/dotnet/api/system.data.datarowcomparer-1.equals?view=netframework-4.8

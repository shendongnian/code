    private const string sqlConnString = "Data Source=myServerAddress;Initial Catalog=myDataBase;Integrated Security=SSPI;" +
      "User ID=myDomain\myUsername;Password=myPassword;";
    DataGrid dataGrid1;
    private void BindData() {
      var table = GetTableMethod("SELECT * FROM Employees;");
      var cInt = table.Columns.Add("My Integer", typeof(int));
      var cStr = table.Columns.Add("Hex View", typeof(string));
      var cBool = table.Columns.Add("Is Even", typeof(bool));
      var dDbl = table.Columns.Add("My Double", typeof(double));
      for (int i = 0; i < table.Rows.Count; i++) { // can't use a foreach here
        DataRow row = table.Rows[i];
        row[cInt] = i;
        row[cStr] = i.ToString("X"); // view in hexadecimal, just for fun
        row[cBool] = ((i % 2) == 0);
        row[dDbl] = (double)i / table.Rows.Count;
      }
      dataGrid1.DataSource = table;
    }
    private DataTable GetTableMethod(string sqlSelectText) {
      var table = new DataTable();
      using (var cmd = new System.Data.SqlClient.SqlCommand(sqlSelectText, new System.Data.SqlClient.SqlConnection(sqlConnString))) {
        try {
          cmd.Connection.Open();
          table.Load(cmd.ExecuteReader());
        } finally {
          cmd.Connection.Close();
        }
      }
      return table;
    }

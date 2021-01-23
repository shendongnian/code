    SqlConnection con = new SqlConnection(connString);
    String queryString = "Select CUSTOMER_NAME from CUSTOMER_DETAIL";
    SqlCommand cmd = new SqlCommand(queryString, con);
    DataTable myTable = new DataTable();
    myTable.Load(cmd.ExecuteReader());
    DataColumn column = myTable.Columns[0]; // zero based index of column, alternatively use column name
    string typeOfColumn = column.DataType.Name; // or column.DataType.FullName to get the fully qualified name of the System.Type

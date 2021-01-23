    string connectionString = String.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 8.0;HDR=YES;IMEX=1;""", YourPath);
        string query = String.Format(SELECT [columnName1],[columnName2],[columnName3] from [{0}$]", "YourSheetNo");
        OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, connectionString);
        DataSet dataSet = new DataSet();
        dataAdapter.Fill(dataSet);
        DataTable YourTable = dataSet.Tables[0];
        listbox1.DataSource =YourTable.Columns["ColumnName1"];
   

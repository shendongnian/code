    DataColumn[] PrimaryKeyColumn = new DataColumn[1]; //Define Primary coloumn
    DataSet dataSet = new DataSet();
    DataTable dataTable = new DataTable();
    ReadAndUpdateExcel.ReadExcel(strPath, sheetName, out dataSet);
    dataSet.Tables.Add(dataTable);
    PrimaryKeyColumn[0] = dataSet.Tables[0].Columns[0];
    dataSet.Tables[0].PrimaryKey = PrimaryKeyColumn;
    string num = dataSet.Tables[0].Rows[dataSet.Tables[0].Rows.IndexOf(dataSet.Tables[0].Rows.Find(strTCName))]["ACNO"].ToString();
    //string country

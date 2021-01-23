    protected void btnSend_Click(object sender, EventArgs e)
    {
    //file upload path
    string path = fileuploadExcel.PostedFile.FileName;
    //Create connection string to Excel work book
    string excelConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source='C:\Users\xxxxxx\Desktop\1-8-13-ct.xlsx';Extended Properties=Excel 12.0;Persist Security Info=False";
    //Create Connection to Excel work book
    OleDbConnection excelConnection =new OleDbConnection(excelConnectionString);
    //Create OleDbCommand to fetch data from Excel
    OleDbCommand cmd = new OleDbCommand("Select * from [Sheet1$]",excelConnection);
    excelConnection.Open();
    OleDbDataReader dReader;
    Datatable table = new DataTable();
    dReader = cmd.ExecuteReader();
    table.Load(dReader);
    SqlBulkCopy sqlBulk = new SqlBulkCopy(strConnection);
    //Give your Destination table name
    sqlBulk.DestinationTableName = "contact";
    sqlBulk.WriteToServer(table);
    excelConnection.Close();
    int numberOfRowsInserted= table.Rows.Count;// <-- this is what was written.
    }

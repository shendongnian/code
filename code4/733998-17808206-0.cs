    protected void btnUpload_Click(object sender, EventArgs e)
    {
    String strConnection = "ConnectionString";
    string connectionString ="";
    if (FileUpload1.HasFile)
    {
        string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
        string fileExtension = Path.GetExtension(FileUpload1.PostedFile.FileName);
        string fileLocation = Server.MapPath("~/App_Data/" + fileName);
        FileUpload1.SaveAs(fileLocation); 
        if (fileExtension == ".xls")
        {
            connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + 
              fileLocation + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\""; 
        }
        else if (fileExtension == ".xlsx")
        {
            connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + 
              fileLocation + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
        } 
        OleDbConnection con = new OleDbConnection(connectionString);
        OleDbCommand cmd = new OleDbCommand();
        cmd.CommandType = System.Data.CommandType.Text;
        cmd.Connection = con;
        OleDbDataAdapter dAdapter = new OleDbDataAdapter(cmd);
        DataTable dtExcelRecords = new DataTable();
        con.Open();
        DataTable dtExcelSheetName = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
        string getExcelSheetName = dtExcelSheetName.Rows[0]["Table_Name"].ToString();
        cmd.CommandText = "SELECT * FROM [" + getExcelSheetName +"]";
        dAdapter.SelectCommand = cmd;
        dAdapter.Fill(dtExcelRecords); 
        GridView1.DataSource = dtExcelRecords;
        GridView1.DataBind(); 
    }

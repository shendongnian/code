    string myConnection ="Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\test.xlsx;Extended Properties="Excel 12.0 ;HDR=YES";
 
        OleDbConnection conn = new OleDbConnection(connstr);
 
        string strSQL = "SELECT * FROM [Sheet$]"; 
        OleDbCommand cmd = new OleDbCommand(strSQL, conn);
 
        DataSet dataset = new DataSet();
        OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
        adapter.Fill(dataset); 
		
        GridViewXYZ.DataSource = dataset; 
        GridViewXYZ.DataBind();

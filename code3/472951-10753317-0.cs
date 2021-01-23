    private void buttonUpload_Click(object sender, EventArgs e)
    {
       string connectionString = String.Format(@"Data Source={0};Extended Properties=""Excel 8.0;HDR=YES;IMEX=1;""", textBoxFileName.Text);
       DataSet objDataset1 = new DataSet();
       using (OleDbConnection objConn = new OleDbConnection(connectionString))
       {
           objConn.Open(); 
  
           using (OleDbCommand objCmdSelect = new OleDbCommand("SELECT * FROM [Sheet1$]", objConn))
           using (OleDbDataAdapter objAdapter1 = new OleDbDataAdapter())
           {
               objAdapter1.SelectCommand = objCmdSelect;    
               objAdapter1.Fill(objDataset1); 
           }
       } 
    }

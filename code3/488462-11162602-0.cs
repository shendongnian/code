    public void computerList()
        {
            //Create SQL strings
            string sql = "SELECT Computers FROM [Sheet1$]";       
           
            using (OleDbConnection dbConnection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.4.0;Data Source=Y:\\\\serverName\\Share\\document.xls;Extended Properties='Excel 12.0 Xml;HDR=YES'"))
            {
               //dbAdapter = new OleDbDataAdapter(sql, dbConnection); //You dont need it
               //dataTable = new DataTable(); //don't need it
               dbConnection.Open();
               using(OleDbCommand oCommand = new OleDbCommand (sql , dbConnection))
               {
                  using(OleDbDataReader dbReader = dbCommand.ExecuteReader())
                  {
                       while (dbReader.Read())
                       {
                          //int iRow = dataTable.Rows.Count; //always zero you never used the datable
                          //MessageBox.Show("Count " + iRow.ToString());
                          //MessageBox.Show(dbReader.ToString());
                          for (int i = 0; i < iRow; i++)
                          {
                              //int loopID = i; //dont need it
                              //string rowData = dataTable.TableName; //Dont need it
                              MessageBox.Show("Count" + i);
                              MessageBox.Show(dbReader.GetString(iRow));
                           }
    
                        }
                   } //reader closed and disposed          
            }//command disposed
        } //connection closed and disposed

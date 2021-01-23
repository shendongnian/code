      DataSet ds = new DataSet();
            try
            {
                
               
                string myConnStr = "";
               
                    myConnStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=MyDataSource;Extended Properties=\"Excel 12.0;HDR=YES\"";
                
                
                OleDbConnection myConn = new OleDbConnection(myConnStr);
                OleDbCommand cmd = new OleDbCommand("select * from [Sheet1$] ", myConn);
                OleDbDataAdapter adapter = new OleDbDataAdapter();
                adapter.SelectCommand = cmd;
                myConn.Open();
                adapter.Fill(ds);
                myConn.Close();
            }
            catch
            { }
            return ds;

      DataSet ds = new DataSet();
      using (OleDbConnection myConnection = new OleDbConnection
             (@"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=C:\Temp\db.accdb"))
                {
                myConnection.Open();
                OleDbDataAdapter myAdapter = new OleDbDataAdapter("SELECT OrderLine.* FROM OrderLine;, myConnection);
                myAdapter.TableMappings.Add("Table", "TestTable");
                myAdapter.Fill(ds);               
                }                    

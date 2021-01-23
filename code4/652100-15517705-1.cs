            mCon.ConnectionString = ("Provider=Microsoft.ACE.OLEDB.12.0;data source=" + pathOfFile + ";Extended Properties=\"Excel 12.0;HDR=YES\";");
            System.Data.OleDb.OleDbCommand Command = new System.Data.OleDb.OleDbCommand();
            DataTable DTable = new DataTable();            
            string strSelectQuery, mstrDBTable;
            System.Data.OleDb.OleDbDataAdapter DataAdapter = new System.Data.OleDb.OleDbDataAdapter();            
                                  
            strSelectQuery = "SELECT * FROM [" + YourSheetName + "]";
            if (mCon.State == ConnectionState.Closed)
            {
                mCon.Open();
            }
            DataAdapter = new System.Data.OleDb.OleDbDataAdapter(strSelectQuery, mCon);
            DataAdapter.Fill(DTable );
            mCon.Close();

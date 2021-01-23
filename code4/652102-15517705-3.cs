            System.Data.OleDb.OleDbConnection mCon;  
            mCon = new System.Data.OleDb.OleDbConnection();
            mCon.ConnectionString = ("Provider=Microsoft.ACE.OLEDB.12.0;data source=" + pathOfFile + ";Extended Properties=\"Excel 12.0;HDR=YES\";");
            System.Data.OleDb.OleDbCommand Command = new System.Data.OleDb.OleDbCommand();
            DataTable DTable = new DataTable();            
            string strSelectQuery, mstrDBTable;
            System.Data.OleDb.OleDbDataAdapter DataAdapter = new System.Data.OleDb.OleDbDataAdapter();            
                                  
            strSelectQuery = "SELECT * FROM [" + YourSheetName + "]"; 
          // YourSheetName is the sheet in xls from where you want to load data e.g Sheet1$
            if (mCon.State == ConnectionState.Closed)
            {
                mCon.Open();
            }
            DataAdapter = new System.Data.OleDb.OleDbDataAdapter(strSelectQuery, mCon);
            DataAdapter.Fill(DTable );
            mCon.Close();

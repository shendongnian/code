         private void SaveData(DataGridView dgv, string selectCommand)  
         {  
            using(SQLiteConnection conn = new SQLiteConnection(connString))
            {
                conn.Open(); 
                SQLiteDataAdapter da = new SQLiteDataAdapter(selectCommand, connString); 
                SQLiteCommandBuilder commandBuilder = new SQLiteCommandBuilder(da); 
                DataTable dt = dgv.DataSource as DataTable;
                da.Update(dt);
                dt.AcceptChanges();
            }
         }

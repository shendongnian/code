    string sqlInsert = "insert into assessment (id) values (?)";
    
            using (OleDbConnection conn = new OleDbConnection(dsn))
            {
    
                OleDbCommand cmd = new OleDbCommand(sqlInsert, conn);
    
                cmd.Parameters.Add("?", OleDbType.VarChar, 50).Value = iDTextBox.Text.Trim().Length == 0 ? storedID.Trim() : "";
    
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }

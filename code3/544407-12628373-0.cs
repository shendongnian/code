    string sqlInsert = "insert into assessment (id) values (?)";
    
            using (OleDbConnection conn = new OleDbConnection(dsn))
            {
    
                OleDbCommand cmd = new OleDbCommand(sqlInsert, conn);
    
                cmd.Parameters.Add("@id", OleDbType.VarChar, 50).Value = iDTextBox.Text.Trim().Length != null ? storedID.Trim() : "";
    
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }

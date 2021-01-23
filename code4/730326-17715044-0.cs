            const string ConnectionPath = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=RetentionDB.mdb";
    
            try
            {
                using (var cn = new OleDbConnection(ConnectionPath))
                using (var cmd = new OleDbCommand("SELECT * FROM RetentionTable WHERE Center = ?", cn))
                {
                    // Parameter names don't matter; OleDb uses positional parameters.
                    cmd.Parameters.AddWithValue("@p0", getCenter(""));
    
                    var objDataSet = new DataSet();
                    var objDataAdapter = new OleDbDataAdapter(cmd);
                    objDataAdapter.Fill(objDataSet,"RetentionTable");
    
                    dataOutput.AutoGenerateColumns = true;
                    dataOutput.DataSource = objDataSet.Tables["RetentionTable"];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                MessageBox.Show(ex.StackTrace.ToString());
            }
        }

     SqlCeConnection connection = new SqlCeConnection(conSTR);
                    SqlCeCommand cmd = new SqlCeCommand("SELECT colour FROM tableColours", connection);
                    connection.Open();
                    DataTable colours = new DataTable();
                    colours.Load(cmd.ExecuteReader());
                    DataRow dr = null;
                    for (int i = 0; i < Colors.Rows.Count; i++)
                    {
                        dr = colours.Rows[i];
                        comboBoxEESS.Items.Add(dr[0].ToString());
        
                    }
                    connection.Close();

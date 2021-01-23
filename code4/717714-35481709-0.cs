     var tableDesc = "DESC table_name";
            try
            {
                Mclient.MySqlCommand tableDescCmd = new Mclient.MySqlCommand(tableDesc, mCon);
                Mclient.MySqlDataReader tableDescDR = tableDescCmd.ExecuteReader();
                while (tableDescDR.Read())
                {
  
                    searchFields.Items.Add(tableDescDR.GetFieldValue<String>(tableDescDR.GetOrdinal("Field")));
                }
                
                tableDescDR.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not retrieve DB Table fields.\n" + ex.Message);
            }

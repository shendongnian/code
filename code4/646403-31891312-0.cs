            string query = @"SELECT DISTINCT floor FROM tbroom ORDER BY floor ASC";
            
            
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader rdr;
                rdr = cmd.ExecuteReader();
                //cboFloor.Items.Clear();
                while (rdr.Read())
                {
                    cboFloor.Items.Add(rdr["floor"]);
                    
                }
            }
            catch (MySqlException mysqlex)
            {
                MessageBox.Show(mysqlex.Message.ToString());
            }
            finally
            {
                con.Close();
            }

    foreach (DataGridViewRow row in dtg_ksluzby.Rows)
            {
                DataGridViewCheckBoxCell chk1 = row.Cells[3] as DataGridViewCheckBoxCell;
                if (Convert.ToBoolean(chk1.Value) == true)
                {
                    SqlCommand prikaz2 = new SqlCommand("INSERT INTO klisluz(text,pocet,akce,subkey) values(@val1,@val2,@val3,@val4) ", spojeni); 
                    prikaz2.Parameters.AddWithValue("@val1", row.Cells["text"].Value);
                    prikaz2.Parameters.AddWithValue("@val2", row.Cells["pocet"].Value);
                    prikaz2.Parameters.AddWithValue("@val3", row.Cells["akce"].Value);
                    prikaz2.Parameters.AddWithValue("@val4", max + 1);                     
                    spojeni.Open();
                    prikaz2.ExecuteNonQuery();
                    spojeni.Close();
                }
            }

    private void cboBranch_Leave(object sender, EventArgs e)
    {
        if (cboBranch.Text.Length > 0)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(serverstring))
                {
                    string query = "SELECT count(*) FROM tblBranches WHERE branch_name=@branch";
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.Add("@branch", MySqlDbType.VarChar, 30).Value = cboBranch.Text;
                        //Use ExecuteScalar
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        if (count <= 0)
                        {
                            MessageBox.Show("The Branch name you entered does not match.", "AFICIONADO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            cboBranch.Select();
                        }
                    }
                }
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

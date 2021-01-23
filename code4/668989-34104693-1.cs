    private void btm_Enter_Click(object sender, EventArgs e)
            {
                SqlCommand cmd = new SqlCommand("select count(*) from Tbl_Username where Username='" + txt_Username.Text + "' and Password='" + txt_Password.Text + "'", _sqlcon);
                _sqlcon.Open();
                int count = 0;
                count = (int)cmd.ExecuteScalar();
                if (count > 0)
                {
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                else
                {
                    DialogResult = System.Windows.Forms.DialogResult.None;
                    MessageBox.Show("UserName or password is wrong", "ENTER", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                
                _sqlcon.Close();
            }

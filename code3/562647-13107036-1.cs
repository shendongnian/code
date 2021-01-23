            con.Open();
            SqlCommand da = new SqlCommand("SELECT * FROM RegistrationTable WHERE Username=@Username AND Password=@Password", con);
            da.Parameters.Add("@Username ", SqlDbType.Varchar);
            da.Parameters["@Username "].Value = tbUsername.Text;
            da.Parameters.Add("@Password", SqlDbType.Varchar);
            da.Parameters["@Password"].Value = tbPassword.Text;
            SqlDataReader reader = null;
            reader = da.ExecuteReader();
            
                if (da.HasRows)
                {
                    MessageBox.Show("*Choose your best candidate. Use a Combobox.\n\n*After choosing, click Submit button to pass your vote!\n\n                           VOTE WISELY!", "How to vote?", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    UserHRForm x = new UserHRForm();
                    x.Show();
                    t.Play();
                    this.Close();
                }
                else
                {
                    SystemSounds.Hand.Play();
                    MessageBox.Show("Access Denied! Account doesn't exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);                        
                }
            }

        private void button1_Click(object sender, EventArgs e)
                {
                    string costring = connection();
                    string MyQuery = "select SUM(balance) from dbo.KmtAccounts where     registernumber='" + txtRegNo.Text + "'";
                    SqlConnection conn = new SqlConnection(costring);
                    SqlCommand cmd = new SqlCommand(MyQuery, conn);
                    conn.Open();
                    lblResult.Text =cmd.ExecuteScalar().ToString();
                    conn.close()
                }

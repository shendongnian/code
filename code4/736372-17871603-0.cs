    private void button1_Click(object sender, EventArgs e)
    {
        Menu m1 = new Menu();
        string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=UserAccounts.accdb; Persist Security Info=False;";
        using (OleDbConnection conn = new OleDbConnection(connectionString))
        {
            try
            {
                conn.Open();
                using (OleDbCommand cmd = new OleDbCommand("Select * from UserAccounts where Username = @Username and Password = @Password"))
                {
                    cmd.Parameters.AddWithValue("@Username", userBox.Text);
                    cmd.Parameters.AddWithValue("@Password", Password.Text);
                    using (OleDbDataReader r = cmd.ExecuteReader())
                    {
                        if (r.HasRows)
                        {
                            // do something here
                        }
                    }
                }
                this.Hide();
                m1.Show();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }

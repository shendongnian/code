    private void button1_Click(object sender, EventArgs e)
    {
        string connectionString="Provider=Microsoft.ACE.OLEDB.12.0;Data Source=UserAccounts.accdb; Persist Security Info=False;";
        using(OleDbConnection conn = new OleDbConnection(connectionString))
        {
            try
            {
                conn.Open();
                MessageBox.Show("Working");
            }
            catch (Exception e)
            {
                MessageBox.Show("Error with the database connection\n\n + e.ToString()");
            }
        }
        Console.ReadKey(true);
    }

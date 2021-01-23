    SqlConnection conn = new SqlConnection("Data Source=SomeDBServer;Initial Catalog=SomeDB;Integrated Security=True");
                conn.Open();
              try{
                SqlCommand command = new SqlCommand(
                              "select max(pid) from table", conn);
                textBox1.Text = command.ExecuteScalar();
                }
    finally {
    conn.Close();
    }

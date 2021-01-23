    private void button1_Click(object sender, EventArgs e)
    {
        int rowsAffected = 0;
        String connString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=|DataDirectory|\\bank.mdf;Integrated Security=True;User Instance=True";
        SqlConnection conn = new SqlConnection(connString);
        SqlCommand cmd = new SqlCommand();
        String cmdText = "insert into marja (ayatollah) values(@n)";
        cmd.CommandText = cmdText;
        cmd.Parameters.AddWithValue("@n", textBox4.Text);
        cmd.Connection = conn;
        conn.Open();
        rowsAffected = cmd.ExecuteNonQuery();
        conn.Close();
        if (rowsAffected > 0)
        {
             dataGridView1.DataSource = marjaBindingSource;
             textBox4.Text = "آیت الله ";
        }
        else
        {
             MessageBox.Show("Error");
        }
    }

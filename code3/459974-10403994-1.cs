    UPDATE yourTable
    SET yourColumn = newValue
    WHERE ID = yourID
    private void button1_Click(object sender, EventArgs e)
    {
        string pass = textBox1.Text;
        sql = new SqlConnection(@"Data Source=PC-PC\PC;Initial Catalog=P3;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = sql;
        cmd.CommandText = "UPDATE MyTable SET MyColumn = @pass WHERE id=@id"
        cmd.Parameters.AddWithValue("@pass", pass);
        cmd.Parameters.AddWithValue("@id", 1);
        sql.Open();
        cmd.ExecuteNonQuery();
        sql.Close();
    }

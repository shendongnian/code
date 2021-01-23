    string sql = "SELECT * FROM jadwalkuliah where Subject = @Subject";
    using (SqlConnection connection = new SqlConnection(...))
    using (SqlDataAdapter adapter = new SqlDataAdapter(sql, connection))
    {
        connection.Open();
        adapter.SelectCommand.Parameters.Add("@Subject", SqlDbType.VarChar)
                                        .Value = textBox1.Text;
        adapter.Fill(dt);
    }

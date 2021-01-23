    using (SqlConnection cnn = new SqlConnection(cnnString))
    using (SqlCommand cmd = new SqlCommand(sql, cnn))
    {
        // use parameters in your SQL statement too, so you can do this
        // and protect yourself from SQL injection, so for example
        // SELECT * FROM table WHERE field1 = @parm1
        cmd.Parameters.AddWithValue("@parm1", val1);
        cnn.Open();
        using (SqlDataReader r = cmd.ExecuteReader())
        {
        }
    }

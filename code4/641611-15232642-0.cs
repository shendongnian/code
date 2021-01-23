    private void button1_Click(object sender, EventArgs e)
    {
        string t1 = textBox1.Text;
        SqlCeConnection conn =
           new SqlCeConnection(@"Data Source=|DataDirectory|\Database1.sdf");
        conn.Open();
        SqlCeCommand cmdInsert = conn.CreateCommand();
        cmdInsert.CommandText = "INSERT INTO table_name (Column1) VALUES (@t1)";
        var parameter = cmdInsert.CreateParameter();
        parameter.Value = t1;
        parameter.ParameterName = "@t1";
        cmdInsert.Parameters.Add(parameter);
    
        cmdInsert.ExecuteNonQuery();
        conn.Close();
    }

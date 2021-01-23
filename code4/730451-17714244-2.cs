    using (OracleCommand crtCommand = new OracleCommand(sql, Con))
    using (OracleDataReader reader = cmd.ExecuteReader())
    {
        while (reader.Read())
        {
            if(!reader.IsDBNull(0) ) richTextBox1.AppendLine(reader[0].ToString(); + ";");
        }
    }

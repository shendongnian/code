    using (OracleCommand crtCommand = new OracleCommand(sql, Con))
    using (OracleDataReader reader = cmd.ExecuteReader())
    {
        while (reader.Read())
        {
               richTextBox1.AppendLine(reader[0].ToString(); + ";");
        }
    }

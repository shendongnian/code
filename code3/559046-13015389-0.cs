    using (SqlConnection cnn = new SqlConnection(connectionString))
    {
        using (SqlCommand cmd = cnn.CreateCommand())
        {
           cmd.CommandText = "Execute some SQL Select here. Doesn't matter what. We just need a reference to the table.";
           cmd.CommandType = CommandType.Text;
           cnn.Open();
           using (SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.KeyInfo))
           {
              schema = rdr.GetSchemaTable();
           }
        cnn.Close();
        }
    }

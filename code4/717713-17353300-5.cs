    using (var con = new SqlConnection(connection))
    {
        using (var schemaCommand = new SqlCommand("SELECT * FROM TestTable;", con))
        {
            con.Open();
            using (var reader = schemaCommand.ExecuteReader(CommandBehavior.SchemaOnly))
            {
                schema = reader.GetSchemaTable();
            }
        }
    }
    // DataTable part is the same
 

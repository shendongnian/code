    DataTable schema = null;
    using (var con = new SqlConnection(connection))
    {
        using (var schemaCommand = new SqlCommand("SELECT * FROM table", con))
        {
            con.Open();
            using (var reader = schemaCommand.ExecuteReader(CommandBehavior.SchemaOnly))
            {
                schema = reader.GetSchemaTable();
            }
        }
    }

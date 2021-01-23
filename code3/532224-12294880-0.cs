    DataTable schema;
    using (var con = new System.Data.SqlClient.SqlConnection(conStr))
    {
        var getSchemaSql = String.Format("SELECT * FROM {0}", tableName);
        using (var schemaCommand = new System.Data.SqlClient.SqlCommand(getSchemaSql, con))
        {
            con.Open();
            using (var reader = schemaCommand.ExecuteReader(CommandBehavior.SchemaOnly))
            {
                schema = reader.GetSchemaTable();
            }
        }
    }

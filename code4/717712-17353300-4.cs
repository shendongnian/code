    DataTable schema = null;
    using (var con = new MySql.Data.MySqlClient.MySqlConnection(connection))
    {
        using (var schemaCommand = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM TestTable", con))
        {
            con.Open();
            using (var reader = schemaCommand.ExecuteReader(CommandBehavior.SchemaOnly))
            {
                schema = reader.GetSchemaTable();
            }
        }
    }
    foreach (DataRow col in schema.Rows)
    {
        Console.WriteLine("ColumnName={0}", col.Field<String>("ColumnName"));
    }
 

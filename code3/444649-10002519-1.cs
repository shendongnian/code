    private static DataTable extractSchemaTable(IEnumerable<String> lines)
    {
        DataTable schema = null;
        var insertLine = lines.SkipWhile(l => !l.StartsWith("INSERT INTO [")).Take(1).First();
        var startIndex = insertLine.IndexOf("INSERT INTO [") + "INSERT INTO [".Length;
        var endIndex = insertLine.IndexOf("]", startIndex);
        var tableName = insertLine.Substring(startIndex, endIndex - startIndex);
        using (var con = new SqlConnection("CONNECTION"))
        {
            using (var schemaCommand = new SqlCommand("SELECT * FROM " tableName, con))
            {
                using (var reader = schemaCommand.ExecuteReader(CommandBehavior.SchemaOnly))
                {
                    schema = reader.GetSchemaTable();
                }
            }
        }
        return schema;
    }

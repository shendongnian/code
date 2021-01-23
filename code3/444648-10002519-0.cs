    private static DataTable extractSchemaTable(IEnumerable<String> lines)
    {
        DataTable schema = null;
        var insertLine = lines.SkipWhile(l => !l.StartsWith("INSERT INTO [")).Take(1).First();
        var startIndex = insertLine.IndexOf("INSERT INTO [") + "INSERT INTO [".Length;
        var endIndex = insertLine.IndexOf("]", startIndex);
        var tableName = insertLine.Substring(startIndex, endIndex - startIndex);
        using (var con = new SqlConnection("CONNECTION"))
        {
            var getSchemaSql = String.Format("SELECT * FROM {0}", tableName);
            using (var schemaCommand = new SqlCommand(getSchemaSql, con))
            {
                using (var reader = schemaCommand.ExecuteReader(CommandBehavior.SchemaOnly))
                {
                    schema = reader.GetSchemaTable();
                }
            }
        }
        return schema;
    }

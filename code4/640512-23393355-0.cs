    public IEnumerable<DbColumnInfo> GetColumns(string connectionString, DbTableInfo table)
    {
        DbProviderFactory factory = DbProviderFactories.GetFactory(this.providerName);
        using (DbConnection connection = factory.CreateConnection())
        using (DbCommand command = factory.CreateCommand())
        {
            connection.ConnectionString = connectionString;
            connection.Open();
            command.Connection = connection;
            command.CommandText = ColumnInfoQuery;
            command.CommandType = CommandType.Text;
            var tableSchema = factory.CreateParameter();
            tableSchema.ParameterName = "@tableSchema";
            tableSchema.DbType = DbType.String;
            tableSchema.Value = table.Schema;
            command.Parameters.Add(tableSchema);
            var tableName = factory.CreateParameter();
            tableName.ParameterName = "@tableName";
            tableName.DbType = DbType.String;
            tableName.Value = table.Name;
            command.Parameters.Add(tableName);
            var dataTable = new DataTable();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    yield return new DbColumnInfo()
                    {
                        Name = reader.GetString(0),
                        OrdinalPosition = reader.GetInt32(1),
                        DataType = reader.GetString(2),
                        IsNullable = reader.GetBoolean(3),
                        IsPrimaryKey = reader.GetBoolean(4),
                        IsForeignKey = reader.GetBoolean(5),
                        IsUnique = reader.GetBoolean(6),
                    };
                }
            }
        }
    }

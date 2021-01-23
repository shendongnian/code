    public DataSet SelectOne(int id)
    {
        DataSet result = new DataSet();
        using (DbCommand command = Connection.CreateCommand())
        {
            command.CommandText = @"
    select * from table1
    select * from table2
            ";
            var param = ParametersBuilder.CreateByKey(command, "ID", id, null);
            command.Parameters.Add(param);
            Connection.Open();
            using (DbDataReader reader = command.ExecuteReader())
            {
                result.MainTable.Load(reader);
                reader.NextResult();
                result.SecondTable.Load(reader);
                // ...
            }
            Connection.Close();
        }
        return result;
    }

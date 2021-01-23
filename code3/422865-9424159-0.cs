    string insertQuery = "INSERT INTO npdata VALUES (@key, @ndata)";
    NpAdapter.InsertCommand = new NpgsqlCommand(insertQuery, conn);
    NpParam = NpAdapter.InsertCommand.Parameters.Add("@key", NpgsqlTypes.NpgsqlDbType.Text);
    NpParam.SourceColumn = "key";
    NpParam.SourceVersion = DataRowVersion.Current;
    NpParam = NpAdapter.InsertCommand.Parameters.Add("@ndata", NpgsqlTypes.NpgsqlDbType.Bigint);
    NpParam.SourceVersion = DataRowVersion.Current;
    NpParam.SourceColumn = "ndata";

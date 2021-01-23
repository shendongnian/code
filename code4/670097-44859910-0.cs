    public DataTable cmdGetRow(String SQL)
        {
                string conString = String.Format("Server={0};Port={1};User Id={2};Password={3};Database={4};",
                _server, _port, _userId, _password, _database);
                NpgsqlConnection connection = new NpgsqlConnection(conString);
                connectin.Open();
                NpgsqlDataAdapter command = new NpgsqlDataAdapter(sql, connection);
                DataSet dataSet = new Dataset();
                dataSet.Reset();
                command.Fill(dataSet);
                return dataSet.Tables[0];
        }

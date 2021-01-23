        public IDataReader ExecuteReaderStoredProcedure(string procName, IUnitOfWork uow, IEnumerable<KeyValuePair<string, object>> parameters)
        {
            var command = Sessions[uow].Connection.CreateCommand();
            command.CommandText = procName;
            command.CommandType = CommandType.StoredProcedure;
            foreach (var param in parameters)
            {
                var parameter = command.CreateParameter();
                parameter.ParameterName = param.Key;
                parameter.Value = param.Value;
                command.Parameters.Add(parameter);
            }
            
            Sessions[uow].Transaction.Enlist(command);
            return command.ExecuteReader();
        }

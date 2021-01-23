    using (IDbConnection newConnection = TransactionScopeMS.Current.GetConnection(connectionString))
            {
                using (IDbCommand newSqlCommand = newConnection.CreateCommand(sproc, CommandType.StoredProcedure, TransactionScopeMS.Current.GetTransaction(connectionString)))
                {
                    foreach (var pram in GetParameters(managedState, typeNamespace, true))
                    {
                        newSqlCommand.Parameters.Add(pram);
                    }
                    newSqlCommand.ExecuteNonQuery();
                    return managedState;
                }
            }

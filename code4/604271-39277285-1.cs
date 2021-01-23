            public virtual int Insert(T obj)
        {
            int result = -2;
            if (!databaseOnline)
            {
                throw new Exception(HttpStatusCode.ServiceUnavailable.ToString());
            }
            if (obj != null)
            {
                try
                {
                    using (IDbConnection dbConnection = ConnectionProvider.OpenConnection())
                    {
                        dbConnection.Open();
                        result = dbConnection.ExecuteScalar<int>(typeof(T).Name + "_c",
                            obj, commandType: CommandType.StoredProcedure);
                    }
                }
                catch (SqlException sqlex)
                {
                    Logger.LogError(sqlex, false);
                    throw;
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex);
                    throw;
                }
            }
            return result;
        }

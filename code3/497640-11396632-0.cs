    public static T LoadEntity<T>(int id, StringBuilder selectQuery) where T : Entity
            {
                dbGenerator _db = dbGenerator.Instance.Database;
                DbCommand selectCommand = _db.GetSqlStringCommand(selectQuery.ToString());
                _db.AddInParameter(selectCommand, "@id", System.Data.DbType.String, Id);
                //EXECUTE THE COMMAND
                using (IDataReader dr = _db.ExecuteReader(selectCommand))
                {
                    if (dr.Read())
                    {
                        T result = default(T);
                        EntityContext.LoadDataReader(result, dr);
                    }
                    dr.Close();
                }
                return result;
            }

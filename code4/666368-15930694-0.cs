     static void ExecuteSql(ObjectContext c, string sql)
        {
            var entityConnection = (System.Data.EntityClient.EntityConnection)c.Connection;
            DbConnection conn = entityConnection.StoreConnection;    
            ConnectionState initialState = conn.State;
            try
            {
                if (initialState != ConnectionState.Open)
                    conn.Open();  
                using (DbCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                if (initialState != ConnectionState.Open)
                    conn.Close(); 
            }
        }

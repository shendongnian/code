       public string GetConnString<T>(T ent)
                where T : ObjectContext
            {
                EntityConnection ec = (EntityConnection)ent.Connection;
                SqlConnection sc = (SqlConnection)ec.StoreConnection;
                return sc.ConnectionString;
            }

       public override IEnumerable<Contact> Fill(IEnumerable<int> ids)
        {
            IEnumerable<Contact> result = null;
            if (ids != null && ids.Count() > 0)
            {
                using (IDbConnection dbConnection = ConnectionProvider.OpenConnection())
                {
                    dbConnection.Open();
                    var predicate = Predicates.Field<Contact>(f => f.id, Operator.Eq, ids);
                    result = dbConnection.GetList<Contact>(predicate);
                    dbConnection.Close();
                }
            }
            return result;
        }

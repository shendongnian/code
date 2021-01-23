        public IDataReader ExecuteQuery(string sqlQuery, params string[] searchTerms)
        {
            var cmd = new SqlCommand { CommandText = sqlQuery };
            for (int i = 0; i < searchTerms.Length; i++)
            {
               cmd.Parameters.AddWithValue(i.ToString(), searchTerms[i]);
            }
            return cmd.ExecuteReader();
        }

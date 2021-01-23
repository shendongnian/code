    public class ScalarReader<T>
    {
        const string MyConnectionString = "...";
        private string _returnColumn, _table, _whereCond;
        private object[] _condParams;
        public ScalarReader(string returnColumn, string table, string whereCond,
                            params object[] condParams)
        {
            _returnColumn = returnColumn;
            _table = table;
            _whereCond = whereCond;
            _condParams = condParams;
        }
        public IEnumerator<T> GetEnumerator()
        {
            using (SqlConnection conn = new SqlConnection(MyConnectionString)) {
                conn.Open();
                string select = String.Format(@"SELECT ""{0}"" FROM ""{1}"" WHERE {2}",
                                              _returnColumn, _table, _whereCond);
                using (SqlCommand command = new SqlCommand(select, conn)) {
                    for (int p = 0; p < _condParams.Length; p++) {
                        command.Parameters.AddWithValue("@" + (p+1), _condParams[p]);
                    }
                    using (SqlDataReader dr = command.ExecuteReader()) {
                        while (dr.Read()) {
                            if (dr.IsDBNull(0)) {
                                yield return default(T);
                            } else {
                                yield return (T)dr[0];
                            }
                        }
                    }
                }
            }
        }
    }

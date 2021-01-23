        public IEnumerable<T> GetByParentId<T>(string table)
        {
            IDbConnection _connection = _dbProvider.GetConnection();
            var _sqlString = "select * from " + table;
            var _ret = _connection.Query<T>(_sqlString);
            return _ret;
        }

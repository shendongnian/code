        public IEnumerable GetByParentId(Type childType, string table)
        {
            IDbConnection _connection = _dbProvider.GetConnection();
            var _sqlString = "select * from " + table;
            var t = typeof(SqlMapper);
            var genericQuery = t.GetMethods().Where(x => x.Name == "Query" && x.GetGenericArguments().Length == 1).First(); // You can cache this object.
            var concreteQuery = genericQuery.MakeGenericMethod(childType); // you can also keep a dictionary of these, for speed.
            var _ret = (IEnumerable)concreteQuery.Invoke(null, new object[] { _connection, _sqlString });
            
            return _ret;
        }

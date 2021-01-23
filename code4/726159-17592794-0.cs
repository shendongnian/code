    public static TOut CountMany<TContext, TOut>(this TContext db, Expression<Func<TContext, TOut>> tableSelector)
            where TContext: DataContext
        {
            var newExpression = (NewExpression) tableSelector.Body;
            var tables =
                newExpression.Arguments.OfType<MethodCallExpression>()
                             .SelectMany(mce => mce.Arguments.OfType<MemberExpression>())
                             .ToList();
            var command = new string[tables.Count];
            for(var i = 0; i < tables.Count; i++)
            {
                var table = tables[i];
                var tableType = ((PropertyInfo) table.Member).PropertyType.GetGenericArguments()[0];
                var tableName = tableType.GetCustomAttribute<TableAttribute>().Name;
                command[i] = string.Format("(SELECT COUNT(*) FROM {0}) AS T{1}", tableName, i);
            }
            var dbCommand = db.Connection.CreateCommand();
            dbCommand.CommandText = string.Format("SELECT {0}", String.Join(",", command));
            db.Connection.Open();
            IDataRecord result;
            try
            {
                result = dbCommand.ExecuteReader().OfType<IDataRecord>().First();
            }
            finally
            {
                db.Connection.Close();
            }
            var results = new object[tables.Count];
            for (var i = 0; i < tables.Count; i++)
                results[i] = result.GetInt32(i);
            var ctor = typeof(TOut).GetConstructor(Enumerable.Repeat(typeof(int), tables.Count).ToArray());
            return (TOut) ctor.Invoke(results);
        }

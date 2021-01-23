		public static IEnumerable<TOne> Query<TOne, TMany>(this IDbConnection cnn, string sql, Func<TOne, IList<TMany>> property, dynamic param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
		{
			var cache = new Dictionary<int, TOne>();
			cnn.Query<TOne, TMany, TOne>(sql, (one, many) =>
			                                  	{
			                                  		if (!cache.ContainsKey(one.GetHashCode()))
			                                  			cache.Add(one.GetHashCode(), one);
			                                  		var localOne = cache[one.GetHashCode()];
			                                  		var list = property(localOne);
			                                  		list.Add(many);
			                                  		return localOne;
			                                  	}, param as object, transaction, buffered, splitOn, commandTimeout, commandType);
			return cache.Values;
		}

	string DisplayProperty = "Name";
	string ValueProperty = "ID";
	IQueryable<Record> SelectRecordProperties<T>(IQueryable<T> query)
	{
		ParameterExpression p = Expression.Parameter(typeof(T), "notused");
		
		MethodInfo ctorMethod = typeof(Record).GetMethod("Create");
		Expression<Func<T, Record>> selectPredicate =
		  Expression.Lambda<Func<T, Record>>(
			Expression.Call(ctorMethod,
		  		Expression.PropertyOrField(p, DisplayProperty),
				Expression.PropertyOrField(p, ValueProperty)), p);
		return query.Select(selectPredicate);
	}
	class Record
	{
		public static Record Create(string display, string value)
		{
			return new Record() { Display = display, Value = value };
		}
		public object Display { get; set; }
		public object Value { get; set; }
	}

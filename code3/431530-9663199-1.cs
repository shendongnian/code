	public static class Helper
	{
		public static IEnumerable<T> BuildOrderBys<T>(
			this IEnumerable<T> source,
			params SortDescription[] properties)
		{
			if (properties == null || properties.Length == 0) return source;
			var typeOfT = typeof (T);
			Type t = typeOfT;
			IOrderedEnumerable<T> result = null;
			var thenBy = false;
			foreach (var item in properties
				.Select(prop => new {PropertyInfo = t.GetProperty(prop.PropertyName), prop.Direction}))
			{
				var oExpr = Expression.Parameter(typeOfT, "o");
				var propertyInfo = item.PropertyInfo;
				var propertyType = propertyInfo.PropertyType;
				var isAscending = item.Direction == ListSortDirection.Ascending;
				if (thenBy)
				{
					var prevExpr = Expression.Parameter(typeof (IOrderedEnumerable<T>), "prevExpr");
					var expr1 = Expression.Lambda<Func<IOrderedEnumerable<T>, IOrderedEnumerable<T>>>(
						Expression.Call(
							(isAscending ? thenByMethod : thenByDescendingMethod).MakeGenericMethod(typeOfT, propertyType),
							prevExpr,
							Expression.Lambda(
								typeof (Func<,>).MakeGenericType(typeOfT, propertyType),
								Expression.MakeMemberAccess(oExpr, propertyInfo),
								oExpr)
							),
						prevExpr)
						.Compile();
					result = expr1(result);
				}
				else
				{
					var prevExpr = Expression.Parameter(typeof (IEnumerable<T>), "prevExpr");
					var expr1 = Expression.Lambda<Func<IEnumerable<T>, IOrderedEnumerable<T>>>(
						Expression.Call(
							(isAscending ? orderByMethod : orderByDescendingMethod).MakeGenericMethod(typeOfT, propertyType),
							prevExpr,
							Expression.Lambda(
								typeof (Func<,>).MakeGenericType(typeOfT, propertyType),
								Expression.MakeMemberAccess(oExpr, propertyInfo),
								oExpr)
							),
						prevExpr)
						.Compile();
					result = expr1(source);
					thenBy = true;
				}
			}
			return result;
		}
		private static MethodInfo orderByMethod =
			MethodOf(() => Enumerable.OrderBy(default(IEnumerable<object>), default(Func<object, object>)))
				.GetGenericMethodDefinition();
		private static MethodInfo orderByDescendingMethod =
			MethodOf(() => Enumerable.OrderByDescending(default(IEnumerable<object>), default(Func<object, object>)))
				.GetGenericMethodDefinition();
		private static MethodInfo thenByMethod =
			MethodOf(() => Enumerable.ThenBy(default(IOrderedEnumerable<object>), default(Func<object, object>)))
				.GetGenericMethodDefinition();
		private static MethodInfo thenByDescendingMethod =
			MethodOf(() => Enumerable.ThenByDescending(default(IOrderedEnumerable<object>), default(Func<object, object>)))
				.GetGenericMethodDefinition();
		public static MethodInfo MethodOf<T>(Expression<Func<T>> method)
		{
			MethodCallExpression mce = (MethodCallExpression) method.Body;
			MethodInfo mi = mce.Method;
			return mi;
		}
	}
    public static class Sample
    {
        private static void Main()
        {
          var data = new List<Customer>
            {
              new Customer {ID = 3, Name = "a"},
              new Customer {ID = 3, Name = "c"},
              new Customer {ID = 4},
              new Customer {ID = 3, Name = "b"},
              new Customer {ID = 2}
            };
   
          var result = data.BuildOrderBys(
            new SortDescription("ID", ListSortDirection.Ascending),
            new SortDescription("Name", ListSortDirection.Ascending)
            ).Dump();
        }
    }
    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

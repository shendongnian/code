	dynamic result = new ExpandoObject();
	dt.AsEnumerable()
	  .GroupBy(r => r.Field<String>("type"))
	  .ToList()
	  .ForEach(g=> ((IDictionary<String, Object>)result)["sum" + g.Key.ToUpper()] = g.Sum(r=>r.Field<Int32>("cnt")));
	Console.WriteLine(result.sumAAA);
	Console.WriteLine(result.sumBBB);

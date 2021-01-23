    public static IEnumerable<HomeInfo> PassesExpression(this IEnumerable<HomeInfo> homes, ExpressionValue expression)
	{
		foreach(HomeInfo home in homes)
		{
			if(/* verify HomeInfo object meets expression */)
				yield return home;
		}
	}

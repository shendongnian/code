    static IQueryable<ResultObject> GenerateOrClause(IQueryable<ResultObject> query, List<Conditions> conditions)
    {
		if( conditions.Count == 0 )
			return query;
			
		var resultQuery = new List<ResultObject>().AsQueryable();
		
        foreach (var condition in conditions)
        {
            switch (condition)
            {
                case Conditions.ByAlpha:
                    resultQuery = resultQuery.Union(query.Where(x => x.AlphaValue));
                    break;
                case Conditions.ByBeta:
                    resultQuery = resultQuery.Union(query.Where(x => x.BetaValue));
                    break;
                case Conditions.ByGamma:
                    resultQuery = resultQuery.Union(query.Where(x => x.GammaValue));
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
		
		return resultQuery;
    }

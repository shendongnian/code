    public static IList<Problem> GetProblemsNewest(int howMuch)
    {
    	using (ProblemClassesDataContext context = new ProblemClassesDataContext())
    	{
    		var problems = (from p in context.Problems orderby p.DateTimeCreated select p).Take(howMuch);
    
    		return problems.ToList();
    	}
    }

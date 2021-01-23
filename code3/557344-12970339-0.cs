    static class PersonSetExtensions
    {
    	public static IQueryable<Person> WhereTempAndNotDeleted(this IQueryable<Person> set)
    	{
    		return set.Where(x => x.IsTemp && !x.IsDeleted);
    	}
    }

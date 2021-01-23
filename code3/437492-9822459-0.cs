	public static class QueryExtensions
	{
		public static IQueryable<T> Published(this IQueryable<T> pages) where T : IPage
		{
			return pages.Where(p => p.State == PageState.Public && p.Published <= DateTime.UtcNow);
		}
		public static IQueryable<T> By(this IQueryable<T> pages, User author) where T : IPage
		{
			return pages.Where(p => p.Author == author);
		}
		public static IEnumerable<Foo> AdvancedThing(this ISession session, string text)
		{
            // I get all the power of NHibernate :)
            return session.CreateQuery("...").SetString("text", text).List<Foo>();
		}
	}

	using System.Data.Entity;
	public class BookAccess : DataAccessBase<Book>
	{
		// Overridden to specify Include()s to be run for each book
		public override IQueryable<Book> Include(IQueryable<Book> entities)
		{
			return base.Include(entities)
					   .Include(e => e.Author);
		}
		
		// A separate Include()-method
		private IQueryable<Book> IncludePages(IQueryable<Book> entities)
		{
			return entities.Include(e => e.Pages);
		}
		
		// Access this method from the outside to retrieve all pages from each book
		public IEnumerable<Book> GetBooksWithPages()
		{
			var books = Include(IncludePages);
		}
	}

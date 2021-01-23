    public class DBAuthorRepository : IAuthorRepository
    {
        public IQueryable<Author> GetAuthors()
        {
            using (var context = new QuotesDataContext())
            {  
                context.DeferredLoadingEnabled = false; // Added this line
                return context.Authors.ToList().AsQueryable();
            }
        }
    }

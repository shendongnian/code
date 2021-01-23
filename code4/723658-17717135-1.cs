    public partial class BookStoreContext
    {
        public IQueryable<Category> GetCategoriesWithBooks()
        {
            return Categories.Include(c => c.Books);
        }
        public IQueryable<Category> GetCategoriesWith(params string[] includeFields)
        {
            var categories = Categories.AsQueryable();
            foreach (string includeField in includeFields)
            {
                categories = categories.Include(includeField);
            }
            return categories;
        }
        // Just another example
        public IQueryable<Category> GetBooksWithAllDetails()
        {
            return Books
                .Include(c => c.Books.Authors)
                .Include(c => c.Books.Pages);
        }
        // yet another complex example
        public IQueryable<Category> GetNewBooks(/*...*/)
        {
            // probably you can pass sort by, tags filter etc in the parameter.
        }
    }

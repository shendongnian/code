    public class SearchBooksByTitleCaseInsensitiveQueryHandler :
        IQueryHandler<SearchBooksByTitleCaseInsensitiveQuery, Book[]>
    {
        private readonly IRepository<Book> bookRepository;
        public SearchBooksByTitleCaseInsensitiveQueryHandler(
            IRepository<Book> bookRepository) {
            this.bookRepository = bookRepository;
        }
        public Book[] Handle(SearchBooksByTitleCaseInsensitiveQuery query) {
            return (
                from book in this.bookRepository.GetAll()
                where book.Title.StartsWith(query.Title)
                select book)
                .ToArray();
         }
    }

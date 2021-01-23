    class TitleSearcherConsumer  {
        IQueryHandler<SearchBooksByTitleCaseInsensitiveQuery, Book[]> query;
        public TitleSearcherConsumer(
          IQueryHandler<SearchBooksByTitleCaseInsensitiveQuery, Book[]> query) {
        }
        public void SomeOperation() {
            this.query.Handle(new SearchBooksByTitleCaseInsensitiveQuery
            {
                Title = "Dependency Injection in .NET"
            });
        }
    }

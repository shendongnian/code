    public class BooksController : ApiController
    {
        [Authorize]
        public IEnumerable<Book> Get()
        {
            var result = new List<Book>()
            {
                new Book()
                {
                    Author = "John Fowles",
                    Title = "The Magus",
                    Description = "A major work of mounting tensions " +
                                    "in which the human mind is the guinea-pig."
                },
                new Book()
                {
                    Author = "Stanislaw Ulam",
                    Title = "Adventures of a Mathematician",
                    Description = "The autobiography of mathematician Stanislaw Ulam, " +
                                    "one of the great scientific minds of the twentieth century."
                }
            };
            return result;
        }
    }

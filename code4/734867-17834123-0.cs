    public List<BookDetails> GetBookDetails()
            {
                XDocument xDOC = XDocument.Load("FilePath");
                List<BookDetails> bookdet = (from xele in xDOC.Descendants("Book")
                                             select new BookDetails
                                             {
                                                 BookName = (string)xele.Element("BookName"),
                                                 Author = (string)xele.Element("Author")
                                             }).ToList<BookDetails>();
                return bookdet;
            }
    
    public class BookDetails
        {
            public string BookName { get; set; }
            public string Author { get; set; }
        }

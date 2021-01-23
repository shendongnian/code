            public List<BookVO> SearchBook(BookVO book)
        {
            List<Books> queryResult = BLDAL.SelectBookFromDB(book);
            List<BookVO> returnedBook = new List<BookVO>();
            foreach (Books dBBook in queryResult)
            {
                BookVO thisBook = new BookVO() {Author = dBBook.Author, Name = dBBook.Name, ISBN = dBBook.BookISBN, Discount = dBBook.Discount, Price = dBBook.Price, Publisher = dBBook.Publisher, ReleaseDate = dBBook.ReleaseDate};
                returnedBook.Add(thisBook);
            };
            return returnedBook;
        }

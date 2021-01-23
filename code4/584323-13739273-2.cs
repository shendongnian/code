            public List<Books> SelectBookFromDB(BookVO book)
        {
            var result = myEntities.Books.ToList();
            if (string.IsNullOrWhiteSpace(book.Author) == false)
            {
                result = result.Where(x => x.Author == book.Author).ToList();
            }
            if (string.IsNullOrWhiteSpace(book.Name) == false)
            {
                result = result.Where(x => x.Name == book.Name).ToList();
            }
            if (string.IsNullOrWhiteSpace(book.Publisher) == false)
            {
                result = result.Where(x => x.Publisher == book.Publisher).ToList();
            }
            if (string.IsNullOrWhiteSpace(book.ISBN) == false)
            {
                result = result.Where(x => x.BookISBN == book.ISBN).ToList();
            }
            if (book.Price != 0)
            {
                result = result.Where(x => x.Price == book.Price).ToList();
            }
            if (book.Discount != 0)
            {
                result = result.Where(x => x.Discount == book.Discount).ToList();
            }
            
            return result;
        }

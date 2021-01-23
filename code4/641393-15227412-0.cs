    public void DeleteBook(int bookId)
        {
            Book book = (Book)bookContext.Books.Where(b => b.Id == bookId).First();
            bookContext.Books.Remove.(book);
        }

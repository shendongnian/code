    [HttpGet]
    public List<Book> Books(int page = 0 , int size = 100){
    
        using(var context = new BooksDataContext()){
            
            List<Book> books = context.Books.OrderBy(t=> t.CreateDate).Skip(page * size).Take(size).ToList();
            return books;
        }
    }

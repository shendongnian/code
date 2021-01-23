    public BookViewModel GetBookById(Guid id)
    {
       try
       {
          var Book = _Books.Collection.Find(Query.EQ("_id", id)).Single();
          return Book;
       }
       catch (Exception e)
       {
          throw new SomeCustomException("Some Custom Message", e);
       }
    }

    public BookViewModel GetBookById(Guid id)
    {
       try
       {
          var Book = _Books.Collection.Find(Query.EQ("_id", id)).Single();
          return Book;
       }
       catch (Exception e)
       {
          Log.Write(e)
          status = "Some Custom Message";
       }
       catch (DoesNotExistException dne)
       {
          Log.Write(dne)
          status = "Some Custom Message about DNE";
       }
    }

    public BookViewModel GetBookById(Guid id)
    {
        try
        {
          var Book = _Books.Collection.Find(Query.EQ("_id", id)).Single();
          return Book;
        }
        catch (SpecificExceptionType1 ex)
        {
            Log.Write(ex);
            throw new Exception("Some nicer message for the users to read", ex);
        }
        catch (SpecificExceptionType2 ex)
        {
            Log.Write(ex);
            throw new Exception("Some nicer message for the users to read", ex);
        }
        catch (Exception ex)
        {
            Log.Write(ex);
            throw;  // No new exception since we have no clue what went wrong
        }
    }

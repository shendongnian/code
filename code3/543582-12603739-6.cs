    try
    {
        DoSomething();
    }
    catch(Exception ex)
    {
        if (ex is SomeException || ex is SomeOtherException)
        {
            throw new LibraryException(ex.Message, ex);
        }
        throw;
    }

    static void handleException(MyBaseException e)
    {
      if (e is UserException)
      {
        // present message to user
      }
      else if (e is DataNotFoundException)
      {
        // log error and show generic error message
      }
      elseif (e is UnexpectedException)
      {
        // log error and try to hide it from the user
      }
      else
      {
        // might want to rethrow the exception, do a general handling,...
      }
    }

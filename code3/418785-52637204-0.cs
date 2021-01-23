    try {
      // Code that throws exception
    }
    catch (Exception e)
    {
      var messages = new List<string>();
      do
      {
        messages.Add(e.Message);
        e = e.InnerException;
      }
      while (e != null) ;
      var message = string.Join(" - ", messages);
    }

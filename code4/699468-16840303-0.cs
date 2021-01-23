    try
    {
       throw new CustomException("An exception.");
    }
    catch (Exception ex)
    {
       if (ex is CustomException)
       {
           // Custom handling
       }
       // Overall handling
    }

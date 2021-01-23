    try
    { 
        throw new CustomException("An exception.");
    }
    catch (Exception ex)
    {
       if (ex is CustomException)
       {
            // Do whatever
       }
       // Do whatever else
    }

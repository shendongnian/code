    public void InterceptedMethod()
    {
      try
      {
        //Some code that fails.
      }
      catch
      {
         HandleException();
      }
    }
    //Intercept this method also
    public void HandleException()
    {
    }

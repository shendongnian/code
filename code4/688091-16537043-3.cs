    public void TryMe()
    {
     try
     {
       SomeMethod();
      }
       catch (Exception exception)
      {
       MessageBox.Show(exception.Message);
       throw;
      }
      }
    

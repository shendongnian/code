     public bool TryMe()
     {
      try
       {
        SomeMethod();
        return true;
       }
       catch (Exception exception)
       {
        MessageBox.Show(exception.Message);
        return false;
       }
      }

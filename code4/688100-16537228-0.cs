    public bool TryMe()
    {
       try
       {
           SomeMethod();
           return true;
       }
       catch (Exception exception)
       {
           return false;
       }
    }
    if (CActions.TryMe())
    {
        this.Hide();
    }
    else
    {
        MessageBox.Show(...);
    }

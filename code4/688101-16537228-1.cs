    public bool TryMe()
    {
       try
       {
           SomeMethod();
           return true;
       }
       catch (Exception exception)
       {
           //insert some logging here, if YOU need the callstack of your exception
           return false;
       }
    }
    if (CActions.TryMe())
    {
        this.Hide();
    }
    else
    {
        MessageBox.Show(...); //insert some meaningful message, useful to END-USER here, not some "Null refrence exception!!11" message, which no one but you will understand
    }

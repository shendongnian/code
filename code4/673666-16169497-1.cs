    void Client_GetPassWordByNameCompleted(object sender, GetPassWordByNameCompletedEventArgs e)
    {
        if (e.Error == null)
        {
        }
        else
        {
            password = e.Result;
            if(EnteredPassword == password)
            {
                isAuthenticated = true;
            }
        }
    }

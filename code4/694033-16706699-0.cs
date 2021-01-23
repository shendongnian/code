    using System.IO.IsolatedStorage;
    private void loginButton_Click(object sender, RoutedEventArgs e)
    {
        if (IsolatedStorageSettings.ApplicationSettings.Contains("email") && IsolatedStorageSettings.ApplicationSettings.Contains("password"))
        {
            if((CType(appSettings("email"),String) == txtEmail.Text) && (CType(appSettings("password"),String) == txtPassword.Text)
            {
                //Successful Login
            }
            else
            {
                //Redirect to registration page
            }
        }
        else //This means he is a first time user as settings have not been stored even once yet
        {
            //Redirect to registration page
        }       
    }

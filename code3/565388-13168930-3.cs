    public void LoginUser(string Email, string Password)
    {
        string Email = "me@example.com";
        string Password = "password";
        string JsonUserAccount = Login(Email, Password);
        if(!string.IsNullOrEmpty(JsonUserAccount))
        {
            Debug.Print("User logged in");
        }
        else
        {
            Debug.Print("Failed to logged in");
        }
    }

    string password = textBoxPassword.Text;
    if (password.Length > 8 && // Must be above 8 characters
        password.Any(char.IsUpper) && //At least one uppercase
        password.Any(char.IsLower) && //At least one lowercase
        password.Any(char.IsSymbol) //At least one symbol
        )
    {
        //Valid password
    }
    else
    {
        //Invalid password
    }

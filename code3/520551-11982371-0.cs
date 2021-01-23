    public void RequestPasswordReset(string email)
    {
        ValidateEmail(email); // May throw exception if invalid
        var user = this.repository.FindByEmail(email);
        if(user != null)
        {
            GenerateTokenAndSendPasswordResetEmail(user);
        }
        else
        {
            SendPasswordResetEmail(email);
        }
    }

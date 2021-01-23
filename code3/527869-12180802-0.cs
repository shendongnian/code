    public bool IsValidEmail(string email)
    {
         bool isValidEmail = false;
         try
         {
             var validEmail = new MailAddress(email);
             isValidEmail = true;
         {
         catch (FormatException ex)
         {
             // The email has not a good format
         }
    }

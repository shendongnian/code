    if (String.IsNullOrWhiteSpace(LastName) && !String.IsNullOrWhiteSpace(FirstName))
    {
       var users = (from u in context.TPM_USER
       where (u.FIRSTNAME.ToLower().Contains(FirstName.ToLower()))
       select u);
    }
    else if (String.IsNullOrWhiteSpace(FirstName) && !String.IsNullOrWhiteSpace(LastName))
    {
       var users = (from u in context.TPM_USER
       where (u.LASTNAME.ToLower().Contains(LastName.ToLower()))
       select u);
    }

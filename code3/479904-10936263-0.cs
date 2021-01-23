    var users = from u in context.TPM_USER select u;
    if (!string.IsNullOrWhiteSpace(FirstName))
        users = users.Where(u => u.FIRSTNAME.ToLower().Contains(FirstName.ToLower());
    if (!string.IsNullOrWhiteSpace(LastName))
        users = users.Where(u => u.LASTNAME.ToLower().Contains(LastName.ToLower());

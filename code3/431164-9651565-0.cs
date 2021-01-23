    var query = _context.Accounts.AsQueryable();
    if (!String.IsNullOrWhiteSpace(account1.UserName))
        query = query.Where(a => a.UserName == account1.UserName);
    if (!String.IsNullOrWhiteSpace(account1.Email))
        query = query.Where(a => a.Email == account1.Email);

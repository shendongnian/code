    public List<AccountDto> getSearchedAccount(int accountid, int userid, string holdername, string type, double balance, string status)
    {
        IQueryable<AccountDto> query = list.AsQueryable();
        if (accountid != default(int))
            query = query.Where(i => i.Accountid.Equals(accountid));
        if (userid != default(int))
            query = query.Where(i => i.Userid.Equals(userid));
        if (!string.IsNullOrEmpty(holdername))
            query = query.Where(i => i.Holdername.Equals(holdername));
        if (!string.IsNullOrEmpty(holdername))
            query = query.Where(i => i.Type.Equals(type));
        if (balance != default(double))
            query = query.Where(i => i.Balance.Equals(balance));
        if (!string.IsNullOrEmpty(holdername))
            query = query.Where(i => i.Status.Equals(status));
        return query.Select(i => i).ToList<AccountDto>();
    }

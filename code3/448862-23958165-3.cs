    public List<int> GetRolesForAccountByEmail(string email)
        {
        var account = db.Accounts.SingleOrDefault(a => a.Email == email);
        if (account == null) return new List<int>();
        List<AccountRoles> accountRoles= db.AccountRoles.ToList<AccountRoles>();
        return accountRoles.Where(a => a.AccountId == account.AccountId).Select(a => Convert.ToInt32(a.RoleId)).ToList();
        }

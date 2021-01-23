    public class AccountDataAccess
    {
        public IEnumerable<Account> Get(Account account)
        {
            var _context = new EntityModel();
            return _context.Where(w => w.UserName == account.UserName
                    && w.Password == account.Password
                    && w.Email == account.Email
                    /* && other you need */
                    ).ToList();
        }
    }

    public sealed class AccountRepository : IAccountRepository, IDisposable
    {
        private AccountContext _context = new AccountContext();
        public IList<AccountEntity> GetAccounts()
        {
            return _context.Accounts
                .OrderBy(x => x.Name)
                .ToList();
        } 
        public void Dispose()
        {
            _context.Dispose();
            _context = null;
        }
    }

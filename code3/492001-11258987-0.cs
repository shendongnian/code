    public class AccountRepository : IAccountRepository
    {
        public Account GetById(Guid id)
        {
            using (AccountContext ctx = new AccountContext())
            {
                var data = (from a in ctx.Accounts
                                   where a.AccountId == id
                                   select new { AccountId = a.AccountId, CustomerId = a.CustomerId, Balance = a.Balance, AccountType = (AccountType)a.AccountTypeId }).First();
                return _accountFactory.Create(data.AccountId, data.CustomerId, data.Balance, data.AccountType);
            }
        }
    }

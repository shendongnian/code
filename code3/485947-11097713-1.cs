    public class AccountManipulatorService : IAccountManipulatorService
    {
        private IAccountRepository _accountRespository;
        public void FreezeAllAccountsForUser(Guid userId)
        {
            IEnumerable<IAccount> accounts = _accountRespository.GetAccountsByUserId(userId);
            using (IUnitOfWork unitOfWork = UnitOfWorkFactory.Create())
            {
                foreach (IAccount account in _accounts)
                {
                    account.Freeze();
                    _accountRespository.Save(account);
                }
            }
        }
    }

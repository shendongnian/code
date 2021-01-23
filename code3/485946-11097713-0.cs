    public class AccountManipulatorService : IAccountManipulatorService
    {
        private IAccountRepository _accountRespository;
        public void CloseAllAccountsForUser(Guid userId)
        {
            IEnumerable<Account> accounts = _accountRespository.GetAccountsByUserId(userId);
            using (IUnitOfWork unitOfWork = UnitOfWorkFactory.Create())
            {
                foreach (Account account in _accounts)
                {
                    account.Close();
                    _accountRespository.Save(account);
                }
            }
        }
    }

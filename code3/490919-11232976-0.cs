    public class FixedBankAccount : IBankAccount
    {
        public FixedBankAccount(RepositoryLayer.IRepository<RepositoryLayer.BankAccount> accountRepository)
        {
            this.accountRepository = accountRepository;
        }
        private readonly RepositoryLayer.IRepository<RepositoryLayer.BankAccount> accountRepository;
        public int BankAccountID { get; set; }
        public void FreezeAccount()
        {
             ChangeAccountStatus();
        }
        private void SendEmail()
        {
        }
        private void ChangeAccountStatus()
        {
            RepositoryLayer.BankAccount bankAccEntity = new RepositoryLayer.BankAccount();
            bankAccEntity.BankAccountID = this.BankAccountID;
            accountRepository.UpdateChangesByAttach(bankAccEntity);
            bankAccEntity.Status = "Frozen";
            accountRepository.SubmitChanges();
        }
    }

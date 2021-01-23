        public void UpdateAccounts()
        {
            RepositoryLayer.Account acc1 = new RepositoryLayer.Account();
            acc1.AccountNumber = 4;
            acc1.AccountType = "TEST";
            acc1.Duration = 10;
            accountRepository.UpdateChangesByAttach(acc1);
            accountRepository.RefreshEntity(acc1);
            accountRepository.SubmitChanges();
        }

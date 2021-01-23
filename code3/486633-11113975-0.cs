    using(var context = new DataContext())
    {
        RepositoryLayer.Repository<RepositoryLayer.Account> selectedRepository = new RepositoryLayer.Repository<RepositoryLayer.Account>();
        selectedRepository.Context = context;
        AccountBusiness accountBl = new AccountBusiness(selectedRepository);
        List<RepositoryLayer.Account> accountList =   accountBl.GetAllAccounts();
    }

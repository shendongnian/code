        public AccountingUow( IRepositoryProvider repositoryProvider)
        {
            Init(repositoryProvider);
        }
        public AccountingUow()
        {
            Init( new RepositoryProvider(new RepositoryFactories()) );
        }

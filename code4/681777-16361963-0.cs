    public MyUoWFactory(IRepositoryFactory<Type1> type1repoFactory, IRepositoryFactory<Type2> type2repoFactory,
                        IRepositoryFactory<Type3> type3repoFactory, IRepositoryFactory<Type4> type4repoFactory,
                        IRepositoryFactory<Type5> type5repoFactory, IRepositoryFactory<Type6> type6repoFactory)
    {
        _type1RepositoryFactory = type1repoFactory;
        _type2RepositoryFactory = type2repoFactory;
        _type3RepositoryFactory = type3repoFactory;
        _type4RepositoryFactory = type4repoFactory;
        _type5RepositoryFactory = type5repoFactory;
        _type6RepositoryFactory = type6repoFactory;
    }
    public IUnitOfWork Create(string userSelectedConnectionString)
    {
        var context = new MyDataContext(userSelectedConnectionString)
        return new MyUoW(context,
                        _type1RepositoryFactory.Create(context), 
                        _type2RepositoryFactory.Create(context), 
                        _type3RepositoryFactory.Create(context),
                        _type4RepositoryFactory.Create(context), 
                        _type5RepositoryFactory.Create(context), 
                        _type6RepositoryFactory.Create(context));
    }

    public class RepositoryModule : RepositoryEntityBase<Module>, IRepositoryModule{
        public RepositoryModule(DbContext context) : base(context, currentState) {}
    }
    //etc
       

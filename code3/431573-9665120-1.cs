    // This class is part of your composition root
    public class NhRepositoryFactory : IRepositoryFactory  
    {
        private readonly Container container;
        public NhRepositoryFactory(Container container)
        {
            this.container = container;
        }
        public IRepository<T> Create<T>() where T : Entity  
        {  
            return this.container.Resolve<NhRepository<T>>();
        }  
    }

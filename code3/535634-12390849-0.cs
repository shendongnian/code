    public class SomeService
    {
        private readonly IRepository<SomeEntity> _repository;
    
        public SchoolService(IRepository<SomeEntity> repository)
        {
            this._repository= repository;
        }
    }

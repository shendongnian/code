    public class DinnerOperation
    {
        private readonly IDinnerRepository repository;
    
        public DinnerOperation(IDinnerRepository dinnerRepository)
        {
            repository = dinnerRepository;
        }
    }

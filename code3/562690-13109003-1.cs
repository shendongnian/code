    class CleanRiders
    {
        private IRiderRepository _repository;
        public CleanRiders(IRiderRepository repository)
        {
            _repository = repository;
        }
        List<Rider> GetCleanRiders()
        {
            _repository.GetRiders.Where(x => x.Doping == false);
        }
    }

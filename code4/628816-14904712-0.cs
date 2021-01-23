    class LoadService
    {    
        ILoadRepository _repository;
        public LoadService(ILoadRepository repository)
        {
             _repository = repository;
        }
        public StagingLoadStatistics InitiateManualRun(string currentUser, string startDate, string endDate)
        {
            var response = _repository.InitiateManualRun(currentUser, startDate, endDate);
            return response;
        }
    }

    public class TrainingService : ITrainingService
    {
        IScormModuleRepository _repository;
        public TrainingService(IScormModuleRepository repository)
        {
            _repository = repository;
        }
    
        public void ResetModule(int id, int userScormModuleId, int currentUser)
        {
            _repository.ResetModule(id, userScormModuleId, currentUser);
        }
    }

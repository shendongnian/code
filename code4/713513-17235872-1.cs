     public interface IApplicaitonSettingsService
    {
       ApplicationSettings Get();
    }
     public class ApplicationSettingsService : IApplicaitonSettingsService 
    {
        private readonly ISiteSettingRepository _repository;
        public ApplicationSettingsService(ISiteSettingRepository repository)
        {
            _repository = repository;
        }
        
        public ApplicationSettings Get()
        {
            SiteSetting setting = _repository.GetAll();
            return setting;
        }
	}

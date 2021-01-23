    public class PhoneFeaturesController : ApiController
    {
        public List<PhoneFeature> GetbyPhoneId(int id)
        {
            var repository = new PhoneFeatureRepository();
            return repository.GetFeaturesByPhoneId(id);
        }
                
        public PhoneFeature GetByFeatureId(int id)
        {
            var repository = new PhoneFeatureRepository();
            return repository.GetFeaturesById(id);
        }        
    }

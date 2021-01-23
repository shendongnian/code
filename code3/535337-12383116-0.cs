    public class WibbleModelBuilder
    {
       private int _userId;
       private WibbleRepository _repo;
       public WibbleModelBuilder(WibbleRepository wibbleRepository, int userId)
       {
           _repo=wibbleRepository;
           _userId=userId;
       }
       public WibbleModel Build()
       {
           var model = new WibbleModel();
           model.LookupList = _repo.GetLookupForUser(_userId);
           return model;
       }
    }

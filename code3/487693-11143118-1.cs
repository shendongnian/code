    public class StoreModelBinder : IModelBinder
    {
        private const string sessionKey = "Store";
        private IStoreObjectRepository storeRepository;
        public StoreModelBinder()
        {
            storeRepository = new StoreObjectRepository();
        }
        public object BindModel(ControllerContext controllerContext,
            ModelBindingContext bindingContext)
        {
            storeRepository = new StoreObjectRepository();
            Uri url = HttpContext.Current.Request.Url;
            string dom = url.Host;
            StoreObject store = storeRepository.Stores.FirstOrDefault(s => s.MainURL == dom);
            if (store != null)
                HttpContext.Current.Session[sessionKey] = store;
            return store;
        }
    }

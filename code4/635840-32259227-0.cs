    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Services.Clear(Type.GetType("System.Web.Http.Validation.IModelValidatorCache, System.Web.Http"));
        }
    }

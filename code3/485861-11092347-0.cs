    interface IContext
    {
        int? ClientID { get; }
    }
    class ContextWrapper : IContext
    {
        private IHttpContext Context { get; set; }
        public ContextWrapper (IHttpContext context)
        {
            Context = context;
        }
        int? ClientID 
        {
            get 
            {
                 return Context.Current.Application["ClientId"] != null
                        ? (int?)HttpContext.Current.Application["ClientId"]
                        : null;
            }
        }
    }
    class YourService
    {
        public YourService(IContext context)
        {
            // store the reference and use in your methods as needed
        }
    }

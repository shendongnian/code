    public class Service : WebService
    {
      public IContextProvider ContextProvider {get;set;}
    
      public Service()
      {
        ContextProvider = DependencyResolver.Current.GetService<IContextProvider>();
      }
    }

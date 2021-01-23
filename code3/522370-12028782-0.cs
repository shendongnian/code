    public ApplicationDataService : IApplicationDataService
    {
      public ApplicationModel LoadApplicationData()
      {
          // process app.config here
      } 
    }
    
    public ViewModelBase<TModel>
    {
      public TModel Model
      {
        get { return model.Value; }
      }
      private readonly Lazy<TModel> model = new Lazy(GetModel);
      
      protected abstract TModel GetModel();
    }
    
    public MainWindowViewModel<ApplicationModel> : ViewModelBase
    {
       protected override ApplicationModel GetModel()
       {
          try
          {
            var dataService = ServiceLocator.GetService<IApplicationDataService>();
            return dataService.LoadApplicationData();
          }
          catch (AnyException e)
          {
             // oops!
          }
       }
    }

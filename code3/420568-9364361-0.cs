    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
				//if (ViewModelBase.IsInDesignModeStatic)
				//{
				//    // Create design time view services and models
				//    SimpleIoc.Default.Register<IDataService, DesignDataService>();
				//}
				//else
				//{
				//    // Create run time view services and models
				//    SimpleIoc.Default.Register<IDataService, DataService>();
				//}
            SimpleIoc.Default.Register<MainViewModel>();
        }
        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }
		  public MainViewModel StaticMain
		  {
			  get
			  {
				  return _staticMain ?? (_staticMain = new MainViewModel());
			  }
		  }
		  private static MainViewModel _staticMain;
		  public MainViewModel NewMain
		  {
			  get
			  {
				  return new MainViewModel();
			  }
		  }
		  public MainViewModel NewIocMain
		  {
			  get
			  {
				  return ServiceLocator.Current.GetInstance<MainViewModel>(Guid.NewGuid().ToString());
			  }
		  } 
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }

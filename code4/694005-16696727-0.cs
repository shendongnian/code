    public AVOViewModel AVO
    {
            get
            {
                if(!SimpleIoc.Default.ContainsCreated<AVOViewModel>())
                    SimpleIoc.Default.Register<AVOViewModel>();
                return ServiceLocator.Current.GetInstance<AVOViewModel>();
            }
    }
    public static void Cleanup()
    {
            // TODO Clear the ViewModels     
            if (SimpleIoc.Default.IsRegistered<AVOViewModel>())
                SimpleIoc.Default.Unregister<AVOViewModel>();
    }

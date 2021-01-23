        static ViewModelLocator()
        {
            if (DesignMode.DesignModeEnabled)
            {
                Container.RegisterType<IYourRepository, YourDesignTimeRepository>();
            }
            else
            {
                Container.RegisterType<IYourRepository, YourRuntimeRepository>();
            }
            Container.RegisterType<YourViewModel>();
        }

        if (ViewModelBase.IsInDesignModeStatic) {
            // put these lines here:
            if (SimpleIoc.Default.IsRegistered<IDataService>()) {
                SimpleIoc.Default.Unregister<IDataService>();
            }
            SimpleIoc.Default.Register<IDataService, Design.DesignDataService>();
        }
        else {
            SimpleIoc.Default.Register<IDataService, DataService>();
        }

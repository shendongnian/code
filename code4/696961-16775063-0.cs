        public ViewModelName MyViewModel
        {
            get
            {
                ViewModelName vm = ServiceLocator.Current.GetInstance<ViewModelName>();
                SimpleIoc.Default.Unregister<ViewModelName>();
                //or SimpleIoc.Default.Unregister<ViewModelName>(MyViewModel);
                return vm;
            }
        }

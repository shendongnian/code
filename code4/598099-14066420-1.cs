     private void Application_Launching(object sender, LaunchingEventArgs e)
        {
            getSource();
        }
     private void Application_Closing(object sender, ClosingEventArgs e)
        {
            saveSource();
        }
     private void saveSource()
        {
            PhoneApplicationService phoneAppservice = PhoneApplicationService.Current;
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
            settings["myValue"] = phoneAppservice.State["myValue"]; //storing the state (image name) to isolated storage
            
        }
        private void getSource()
        {
            PhoneApplicationService phoneAppservice = PhoneApplicationService.Current;
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
            object myValue;
            if(settings.TryGetValue<object>("myValue", out myValue))
            {
                phoneAppservice.State["myValue"] = myValue; // saving the state from isolated storage
            }
        }
 

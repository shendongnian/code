     Mutex myMutex ;
     private void Application_Startup(object sender, StartupEventArgs e)
     {
        bool aIsNewInstance = false;
        myMutex = new Mutex(true, "MyWPFApplication", out aIsNewInstance);  
           if (!aIsNewInstance)
            {
              MessageBox.Show("Already an instance is running...");
              App.Current.Shutdown();  
            }
      }

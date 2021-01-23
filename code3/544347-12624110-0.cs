    protected override void OnStartup(StartupEventArgs e)
    {
        //Start your animation here.
        Task.Factory.StartNew(() => 
        {
           //Start long loading operation here
           
           Application.Current.Dispatcher.Invoke(
              new Action(() => 
                 { 
                    //Stop your animation here
                    //Note: it needs to run on the UI thread, so we dispatch it.
                 })
           );
        }
    }

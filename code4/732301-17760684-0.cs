    static EventWaitHandle s_event;
    bool created;  
    App()
    {
        s_event = new EventWaitHandle (false, EventResetMode.ManualReset, "my program#startup", out created) ;
        if (!created)
        {
            if (MessageBoxResult.OK == MessageBox.Show("Only 1 instance of this application can run at a time", "Error", MessageBoxButton.OK))
                App.Current.Shutdown();
        }
    }

    if (!YOURCONTROL.Dispatcher.CheckAccess())
    {
        YOURCONTROL.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal,
            new Action(delegate()
            {
                //do something with the control/form/...
            }));
    }
    else
    {
        //update your control
    }

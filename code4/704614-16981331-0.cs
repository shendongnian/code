    Session session = null;
    Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal,
        (Action)(() => { 
                         session = new ThirdPartyTool.Session();
                         session.Open(view);
                       } ));

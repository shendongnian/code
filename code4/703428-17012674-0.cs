    // CurrentPlaylistItem = pli ; -- not good
    Application.Current.Dispatcher.Invoke (() =>
    {
        // clear item
        CurrentPlaylistItem = null ;
        Application.Current.Dispatcher.Invoke (() =>
        {
            // set new item, possibly same as old item
            // but WPF will have forgotten that because
            // data bindings caused by the assignment above
            // have already been queued at the same DataBind 
            // level and will execute before this assignment
            CurrentPlaylistItem = pli ; 
        }, DispatcherPriority.DataBind) ;
    }) ;

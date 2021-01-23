    // CurrentPlaylistItem = pli ; -- not good
    Application.Current.Dispatcher.Invoke (new Action (() =>
    {
        // clear item
        // null doesn't work, because TransitionableContentControl's
        // inner ContentControl would be empty and the brush created 
        // from it would be a null brush (no visual effect)
        CurrentPlaylistItem = new PlaylistItem () ;
        this.OnPropertyChanged ("CurrentPlaylistItem") ;
        Application.Current.Dispatcher.Invoke (new Action (() =>
        {
            // set new item, possibly same as old item
            // but WPF will have forgotten that because
            // data bindings caused by the assignment above
            // have already been queued at the same DataBind 
            // level and will execute before this assignment
            CurrentPlaylistItem = pli ; 
            this.OnPropertyChanged ("CurrentPlaylistItem") ;
        }), DispatcherPriority.DataBind) ;
    })) ;

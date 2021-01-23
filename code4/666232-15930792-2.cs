    IsLoading = true;
    Dispatcher.BeginInvoke(DispatcherPriority.Background,
        new Action(delegate() { 
            LoadData();
            IsLoading = false;
         }));

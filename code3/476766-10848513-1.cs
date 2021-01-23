    Class MyApp : INotifyPropertyChanged
      ObservableCollection<Post> Posts {get;set;}
      void RefreshPost(int id);
    
    Class Post : INotifyPropertyChanged
      bool IsRefreshing {get;set;}

    public void OnNavigatedTo(NavigationContext navigationContext)
    {
      SharedView view = (SharedView)ServiceLocator.Current.GetInstance(typeof(SharedView));
      ParentView.MyContentControl.Content = view;
    }

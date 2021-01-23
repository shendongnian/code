    bool isFirstTime = true;
    public void OnNavigatedTo(NavigationContext navigationContext)
    {
      if (isFirstTime)
      {
        isFirstTime = false;
        return;
      }
      SharedView view = (SharedView)ServiceLocator.Current.GetInstance(typeof(SharedView));
      ParentView.MyContentControl.Content = view;
    }

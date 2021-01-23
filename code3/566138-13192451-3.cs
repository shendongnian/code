    protected async override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
    {
      ProggressBarVisible(true);
      try
      {
        MainContentGrid.Visibility = Visibility.Collapsed;       
        this.DataContext = await MyDataSource.GetData(navigationParameter);
      }
      finally
      {
        ProggressBarVisible(false);
        MainContentGrid.Visibility = Visibility.Visible;
      }
    }
    private void ProggressBarVisible(bool visible)
    {
      ProgressRingLoad.Visibility = visible ? Visibility.Visible : Visibility.Collapsed;
      ProgressRingLoad.IsActive = visible;
    }

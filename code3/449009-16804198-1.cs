    protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
    {
      string strItemIndex;
      if (NavigationContext.QueryString.TryGetValue("goto", out strItemIndex))
      {
        myPivot0.SelectedIndex = Convert.ToInt32(strItemIndex);
      }
      base.OnNavigatedTo(e);
    }

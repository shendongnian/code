    protected override void OnNavigatedFrom(NavigationEventArgs e)
    {
      base.OnNavigatedFrom(e);
    
      // Remove current page from history
      var pageStackEntry = Frame.BackStack.Last(entry => entry.SourcePageType == this.GetType());
      Frame.BackStack.Remove(pageStackEntry);
    }

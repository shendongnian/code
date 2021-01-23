    List<UserControl> navigationStack = new List<UserControl>();
    
    public void NavigateTo(UserControl newUC)
    {
      // when navigating to a new control, keep the old one in memory
      if (this.Frame.Content != null) 
        navigationStack.Add(this.Frame.Content as UserControl);
      this.Frame.Content = newUC;
    }
    
    public void NavigateBack()
    {
      // when navigating back to an old control in memory, 
      // retrieve it off the navigation stack
      UserControl oldUC = navigationStack.LastOrDefault();
      if (oldUC != null)
      {  
         navigationStack.Remove(oldUC);
         this.Frame.Content = oldUC;
      }
    }

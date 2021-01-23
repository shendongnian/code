    public Main()
    {
      User.AvailabilityChanged += UserAvailabilityChanged;
    }
    
    private static void UserAvailabilityChanged(object sender, AvailabilityChangedEventArgs e)
    {
      var user = sender as User;
    
      if (user == null) return;
    
      System.Diagnostics.Debug.WriteLine(user.IsSignedIn);
    }

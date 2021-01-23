    // You can realize INotificationChanged here too if you need
    sealed class Preference 
    {
      public Preference(string name, bool isSelected)
      {
        Name = name; 
        IsSelected = isSelected;
      }
      public string Name { get; private set; }
      public bool IsSelected { get; set; }  
    }
    sealed class User : INotificationChanged
    {
      private ObservaleCollection<Preference> viewPreferences;
      public event PropertyChangedEventHandler PropertyChanged;
      public User(PreferenceCollection preferences)
      {
        PreferenceTitle = preferences.Title;
        // put info to collection
      }
      public ObservaleCollection<Preference> Preferences
      {
        get { return preferences; }
      }
      
      // You can remove set if you don't want to set it directly
      public UserId { get; set; }
      public UserName { get; set; }
      public PreferenceTitle { get; private set; }
      
      // Use it to update data in view
      protected void OnPropertyChanged(string name)
      {
          PropertyChangedEventHandler handler = PropertyChanged;
          if (handler != null)
          {
              handler(this, new PropertyChangedEventArgs(name));
          }
      }
    }

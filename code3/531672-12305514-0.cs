    var settings = new ObservableCollection<SettingsClassType>();
    SettingsCollView = CollectionViewSource.GetDefaultView(settings);
    SettingsCollView.Filter += (o) => {
      var setting = (SettingsClassType)o;
      return string.IsNullOrEmpty(YourSearchInput)
             || setting.Name.Contains(YourSearchInput);
    }
    
    private string yourSearchInput;
    public bool YourSearchInput
    {
      get { return yourSearchInput; }
      set
      {
        if (value == yourSearchInput) {
          return;
        }
        yourSearchInput= value;
        // filer your collection here
        SettingsCollView.Refresh();
        this.NotifyPropertyChanged("YourSearchInput");
      }
    }

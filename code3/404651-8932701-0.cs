    public class Test : INotifyPropertyChanged {
      public event PropertyChangedEventHandler PropertyChanged;
      private string _Property = string.Empty;
      public string Property {
        get { return _Property; }
        set {
          _Property = value;
          OnPropertyChanged("Property");
        }
      }
      private void OnPropertyChanged(string propertyName) {
        if (PropertyChanged != null)
          PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
      }
   }

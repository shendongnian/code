    public class Test : INotifyPropertyChanged {
      public event PropertyChangedEventHandler PropertyChanged;
      private string _PropertyText = string.Empty;
      public string PropertyText {
        get { return _PropertyText; }
        set {
          _PropertyText = value;
          OnPropertyChanged("PropertyText");
        }
      }
      private void OnPropertyChanged(string propertyName) {
        if (PropertyChanged != null)
          PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
      }

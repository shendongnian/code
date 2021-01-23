    public class MainWindowViewModel : INotifyPropertyChanged {
      public event PropertyChangedEventHandler PropertyChanged;
    
      private void raisePropertyChanged(string propertyName) {
        if (PropertyChanged != null) PropretyChanged(this, new PropertyChangedEventArgs(propertyName));
      }
    }

    public class Kurssit : INotifyPropertyChanged {
      private string _Oppilaanimi;
      private bool _IsChecked;
      public string OppilaanNimi {
        get { return _Oppilaanimi; }
        set {
          if (_Oppilaanimi != value) {
            _Oppilaanimi = value;
            PropertyChanged(this, new PropertyChangedEventArgs("OppilaanNimi"));
          }
      }
      public bool IsChecked {
        get { return _IsChecked ; }
        set {
          if (_IsChecked != value) {
            _IsChecked = value;
            PropertyChanged(this, new PropertyChangedEventArgs("IsChecked"));
          }
      }
      public event PropertyChangedEventHandler PropertyChanged;
    }

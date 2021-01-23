    public class Colours : INotifyPropertyChanged {
      public event PropertyChangedEventHandler PropertyChanged;
      private Color _ColourP1;
      public void Reset() {
        this.ColourP1 = Color.Red;
      }
      private void OnChanged(string propName) {
        if (PropertyChanged != null)
          PropertyChanged(this, new PropertyChangedEventArgs(propName));
      }
      public Color ColourP1 {
        get { return _ColourP1; }
        set {
          _ColourP1 = value;
          OnChanged("ColourP1");
        }
      }
    }

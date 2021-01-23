    public class PanelEx : Panel, INotifyPropertyChanged {
      public event PropertyChangedEventHandler PropertyChanged;
      public new int Width {
        get { return base.Width; }
        set {
          base.Width = value;
          OnPropertyChanged("Width");
        }
      }
      public new int Height {
        get { return base.Height; }
        set {
          base.Height = value;
          OnPropertyChanged("Height");
        }
      }
      private void OnPropertyChanged(string propertyName) {
        if (PropertyChanged != null)
          PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
      }
    }

    public class Obj : INotifyPropertyChanged {
      public event PropertyChangedEventHandler PropertyChanged;
      private string name;
      private BindingSourceSimpleTest.Color color;
      protected void OnPropertyChanged(string propName) {
        if (PropertyChanged != null) {
          PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
      }
      public string Name {
        get { return name; }
        set {
          name = value;
          OnPropertyChanged("Name");
        }
      }
      public BindingSourceSimpleTest.Color Color {
        get { return color; }
        set {
          color = value;
          OnPropertyChanged("Color");
        }
      }
    }

    public class CParameters : INotifyPropertyChanged {
      public event PropertyChangedEventHandler PropertyChanged;
      private void OnPropertyChanged(string propertyName) {
        var handle = PropertyChanged;
        if (handle != null) handle(this, new PropertyChangedEventArgs(propertyName));
      }
      private static readonly CParameters instance = new CParameters();
  
      public static CParameters Instance {
         get { return instance; }
      }
    
      private Color colorBegin;
    
      private Color colorEnd;
      public Color ColorBegin {
        get { return colorBegin; }
        set {
          if (value != colorBegin) {
            colorBegin=value;
            OnPropertyChanged("ColorBegin");
          }
        }
      }
      public Color ColorEnd {
        get { return colorEnd; }
        set { 
         if (value != colorEnd) {
           colorEnd = value;
           OnPropertyChanged("ColorEnd");
         }
       }
      }
    }
   

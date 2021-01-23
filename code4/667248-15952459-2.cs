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
    
      private Brush colorBegin;
    
      private Brush colorEnd;
      public Brush ColorBegin {
        get { return colorBegin; }
        set {
          if (value != colorBegin) {
            colorBegin=value;
            OnPropertyChanged("ColorBegin");
          }
        }
      }
      public Brush ColorEnd {
        get { return colorEnd; }
        set { 
         if (value != colorEnd) {
           colorEnd = value;
           OnPropertyChanged("ColorEnd");
         }
       }
      }
    }
   

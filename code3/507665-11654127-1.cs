     public sealed class EnvironmentalVariables : INotifyPropertyChanged {
          private static readonly EnvironmentalVariables instance = new EnvironmentalVariables();
          public static EnvironmentalVariables Instance {
               get 
               {
                   return instance;
               }
          }
          private EnvironmentalVariables() { }
          private bool tooltipEnable;
          public bool ToolTipEnable {
               get {
                    return tooltipEnable;
               }
               set {
                    if(tooltipEnable != value) {
                         tooltipEnable = value;
                         this.RaiseNotifyPropertyChanged("ToolTipEnable");
                    }
               }
          }
          private void RaiseNotifyPropertyChanged(string property) {
               var handler = PropertyChanged;
               if(handler != null) {
                    handler (this, new PropertyChangedEventArgs(property));
               }
          }
          public event PropertyChangedEventHandler PropertyChanged;
     }

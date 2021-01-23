    public class ViewModel : INotifyPropertyChanged
    {
         public Brush MyBackground 
         { 
              get { return background_; } 
              set {
                    background_ = value;
                    PropertyChanged(this, new PropertyChangedEventArg("MyBackground");
              }
         }
         
         public ICommand OnClickCmd
         {
              get {
                   return new DelegateCommand(()=>{ // DelegateCommand implements ICommand
                      if(!isBackgroundSet) {
                          background = Brushes.Red;
                          isBackgroundSet_ = true;    
                      }
                   });
              }
         }
         private Brush background_;
         private bool isBackgroundSet_;
         private event PropertyChangedEventHandler PropertyChagned;
     }

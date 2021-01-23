    public class ViewModel :INotifyPropertyChanged IViewModel
    {
       private string _stringPropertyToBindTo { get; set; }
       public string StringPropertyToBindTo
       {
          get { return _stringPropertyToBindTo; }
          set
          {
             _stringPropertyToBindTo = value;
             PropertyChanged(this, new PropertyChangedEventArgs("StringPropertyToBindTo"));
          }
       }
       
       public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }

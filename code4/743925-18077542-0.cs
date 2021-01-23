    public class ViewModel : INotifyPropertyChanged
    {
      private foo _property;
      public foo Property
      { 
         get{ return _property; }
         set{ _property = value; OnPropertyChanged(); }
      }
      .................

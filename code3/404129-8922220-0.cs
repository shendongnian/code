    public class PageMainViewModel : ViewModelBase
    {
      LoggedOnUserInfo UserInfo;
      public LoggedOnUser UserInfo
      {
         get {return _UserInfo;}
         set
         {
            _UserInfo = value;
            RaisePropertyChanged("UserInfo");
         }
      }
    }

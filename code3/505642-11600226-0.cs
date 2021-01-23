    public class MainViewModel : INotifyPropertyChanged
    {
       public ObservableCollection<RSSItem> RSSItems
       {
          get;
          set;
       }
       // Other stuff applicable to the main window.
    }

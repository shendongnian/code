    public class MyViewModel :INotifyPropertyChanged    
    {
       public IEnumerable<ActivityItem> AllItems {get;set;} //needs to NotifyPropertyChanged(FilteredItems)
       public Func<ActivityItem, bool> Filter { get;set;} //needs to NotifyPropertyChanged(FilteredItems)
       public IEnumerable<ActivityItem> FilteredItems { get { return from x in AllItems where Filter(x) select x; }}
    }
      

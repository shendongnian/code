    public class ViewModel
    {
    
          public ViewModel()
          {
               Items = new ObservableCollection<Item>();
               Items.CollectionChanged += (o, e) => NotifyPropertyChanged("ItemNames");
          }
          public ObservableCollection<Item> Items { get; private set; }
          public string ItemNames { get { return String.Join(",", Items); } }
    }

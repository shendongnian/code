    public class Item : INotifyPropertyChanged
    {
       public event PropertyChangedEventHandler PropertyChanged;
    
       private int _Id;
       private HashSet<int> _Pairs;
       private ItemState _State;
       private String _ItemName;
       private String _Note;
    
       public Item()
       {
          Id = IdCounter++;
          Pairs = new HashSet<int>();
          State = ItemState.NEW;
          Name = "#noname";
          Note = "";      
       }
    
       public int Id
       {
          get { return _Id; }
          set
          {
             if(_Id != value)
             {
                _Id = value;
                NotifyPropertyChanged("Id");
             }
          }
       }
    
       ... Implement other properties like above/below
     
       // Dont use 'Name' as a property type
       public String ItemName
       {
          get { return _ItemName; }
          set
          {
             if(_ItemName!= value)
             {
                _ItemName= value;
                NotifyPropertyChanged("ItemName");
             }
          }
       }
    
       ...
    
       public void NotifyPropertyChanged(String propertyName)
       {
          PropertyChangedEventHandler prop_changed = PropertyChanged;
          if (prop_changed != null)
          {
             prop_changed(this, new PropertyChangedEventArgs(propertyName));
          }
       }
    }

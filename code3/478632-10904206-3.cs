    public class MyModel : INotifyPropertyChanged
    {
    
      private ObservableCollection<SomeObject> _items;
      public ObservableCollection<SomeObject> Items
      {
        get { return _items; }
        set
        {
            _items = value;
            NotifyPropertyChanged( "Items" );
        }
      }
    
      private SomeObject _selected;
      public SomeObject  Selected
      {
        get { return _selected; }
        set
        {
            _selected = value;
            NotifyPropertyChanged( "Selected" );
        }
      }
    
      public void SomeMethodThatPopulatesItems()
      {
        // create/populate the Items collection
        Selected = Items[0];
      }
      // Implementation of INotifyPropertyChanged excluded for brevity
    }

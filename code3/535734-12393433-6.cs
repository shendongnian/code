    public ObservableCollection<DataItem> Items {get;set;}
    
    private DataItem _selected;
    public DataItem Selected
    {
      get {return _selected;}
      set 
    {
      _selected = value;
      //ha! item selected!!! handle it
    }
    }
    
    public class DataItem 
    {
       public string Name {get;set;}
    }

    public class ItemModel
    {
    public bool IsSelected {get;set;}
    public ObservableCollection<ItemModel> Items {get;set;}
    
    public ItemModel()
    {
    Items = new ObservableCollection<ItemModel>();
    }
    }

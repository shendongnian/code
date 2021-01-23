    public class ItemsVM
    {
    
    // You can always keep the items sorted based on you business rules
    public ObservableCollection<ItemModel> Items {get;set;}
    
    public ItemVM()
    {
    Items = new ObservableCollection<ItemModel>(){
    new ItemModel(), new ItemModel()
    };
    }
    }

    public partial class MainPage : PhoneApplicationPage
    {
    public class DataBaseEntry 
    {
        public string Id {get;set;}
        public string Name {get;set;}
    }
    public ObservableCollection<DataBaseEntry> Items {get;set;}
    public MainPage()
    {
        InitializeComponent();
        Items = new ObservableCollection<DataBaseEntry>();
        PopulateListBox();
    }
    public void PopulateListBox()
    {
        updateDatabase();
        deleteRow(i);
        int rowCount = noofrows();
        for (int i = 1; i <= rowCount; i++)
        {
            var entry = new DataBaseEntry
            {
                Id = returnID(i),
                Name = SelectName(i)
            }
            Items.Add(entry);
        }
    }
    //this will remove item from Items collection and updates listbox
    public void DeleteItemById(int id) 
    {
        var item = Items.FirstOrDefault(item => item.id == id.ToString());
        if (item != null) 
        {
            Items.Remove(item);
        }
        string str2 = "delete  from Details where id =" + id;
        (Application.Current as App).db.SelectList(str2);
    }

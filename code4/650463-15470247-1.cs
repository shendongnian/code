    ObservableCollection<MyItem> MyItems {get; set;}
    MyItem SelectedItem {get; set;}
    
    public class MyItem : INotifyPropertyChanged
    {
        public string Name {get; set;}
    	public string Path {get; set;}
    }

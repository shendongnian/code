    ObservableCollection<MyObject> OuterList = new ObservableCollection<MyObject>();
    
    //...
    
    
    public class MyObject
    {
        public ObservableCollection<FileInfo> ImageCollection {get; set;}
        public MyObject()
        {
            ImageCollection = new ObservableCollection<FileInfo>();
        }
    }

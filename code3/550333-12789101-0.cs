    ObservableCollection<MyObject> OuterList = new ObservableCollection<MyObject>();
    
    //...
    
    
    public class MyObject
    {
        public ObservableCollection<MyInnerObject> InnerList {get; set;}
        public MyObject()
        {
            InnerList = new ObservableCollection<MyInnerObject>();
        }
    }

    class MyWindowClass
    {
        public MyWindowClass():base()
        {
             ...
             InitializeComponent();
             myItems = new ObservableCollection<MyObject>();
             myItems.Add(new MyObject);// First Element
             myItems.Add(new MyObject);// Second Element
             ...
             myItems.Add(new MyObject);// Last Element
             ...
        }
        public ObservableCollection<MyObject> myItems
        {
            get{ ... }
            set{ ... }
        }
        void setItem(int index,MyObject newObject)
        {
            ...
            myItems[index]=newObject;
            ...
        }
    }
    public class MyObject
    {
        public string MyField{get;set;}
    }

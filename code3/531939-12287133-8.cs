    class MyWindowClass: INotifyPropertyChanged
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
        int columns=5;
        public int ColumnsInArray
        {
            get{return columns;} 
            set {columns=value; NotifyPropertyChanged("ColumnsInArray");}
        }
        public ObservableCollection<MyObject> myItems
        {
            get{ ... }
            set{ ... }
        }

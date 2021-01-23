    class MyWindowClass
    {
        public MyWindowClass():base()
        {
             ...
             InitializeComponent();
             ObservableCollectionOfMyObjects = new ObservableCollection<MyObject>();
             ObservableCollectionOfMyObjects.Add(new MyObject);// First Element
             ObservableCollectionOfMyObjects.Add(new MyObject);// Second Element
             ...
             ObservableCollectionOfMyObjects.Add(new MyObject);// Last Element
             ...
        }
        public ObservableCollection<MyObject> ObservableCollectionOfMyObjects
        {
            get{ ... }
            set{ ... }
        }
        void setItem(int index,MyObject newObject)
        {
            ...
            ObservableCollectionOfMyObjects[index]=newObject;
            ...
        }
    }

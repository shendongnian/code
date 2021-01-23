    public class MyClass : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged("Name"); }
        }
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class Class1
    {
        private ObservableCollection<MyClass> _myCollection = new ObservableCollection<MyClass>();
        public ObservableCollection<MyClass> MyCollection
        {
            get { return _myCollection; }
            set { _myCollection = value; }
        }
        public Class1()
        {
            // hook up this event at the appropriate place, does not have to be the ctor
            MyCollection.CollectionChanged += MyCollection_CollectionChanged;
            MyClass m = new MyClass() { Name = "Example" };
            MyCollection.Add(m); // calls ExecuteOnAnyChangeOfCollection
            m.Name = "ChangedValue"; // calls ExecuteOnAnyChangeOfCollection
        }
        void MyCollection_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (MyClass item in e.NewItems)
                    item.PropertyChanged += MyClass_PropertyChanged;
            }
            if (e.OldItems != null)
            {
                foreach (MyClass item in e.OldItems)
                    item.PropertyChanged -= MyClass_PropertyChanged;
            }
            ExecuteOnAnyChangeOfCollection();
        }
        void MyClass_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            ExecuteOnAnyChangeOfCollection();
        }
        private void ExecuteOnAnyChangeOfCollection()
        {
            // handling code ...
            System.Windows.MessageBox.Show("Collection has changed.");
        }

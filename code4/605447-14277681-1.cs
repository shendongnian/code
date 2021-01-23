    public partial class MainWindow : Window , INotifyPropertyChanged
    {
        private CustomObject _mySelectedItem;
        private CustomObject _mySelectedValue;
        private ObservableCollection<CustomObject> _items = new ObservableCollection<CustomObject>();
        private ObservableCollection<CustomObject> _items2 = new ObservableCollection<CustomObject>();
        public MainWindow()
        {
            InitializeComponent();
            MyItemSource1.Add(new CustomObject { Name = "Stack" });
            MyItemSource1.Add(new CustomObject { Name = "Overflow" });
            MyItemSource2.Add(new CustomObject { Name = "Stack" });
            MyItemSource2.Add(new CustomObject { Name = "Overflow" });
        }
     
        public ObservableCollection<CustomObject> MyItemSource1
        {
            get { return _items; }
            set { _items = value; }
        }
    
        public ObservableCollection<CustomObject> MyItemSource2
        {
            get { return _items2; }
            set { _items2 = value; }
        }
        public CustomObject MySelectedItem
        {
            get { return _mySelectedItem; }
            set { _mySelectedItem = value; NotifyPropertyChanged("MySelectedItem"); }
        }
      
        public CustomObject MySelectedValue
        {
            get { return _mySelectedValue; }
            set { _mySelectedValue = value; NotifyPropertyChanged("MySelectedValue"); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
    
    public class CustomObject
    {
        public string Name { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }

        public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModel();
        }
    }
    public class ViewModel 
    {
        public ViewModel()
        {
            Foos = new ObservableCollection<Foo>();
        }
        public ObservableCollection<Foo> Foos { get; set; }
    }
    public class Foo : INotifyPropertyChanged
    {
        static int _nextId;
        public int Id { get; private set; }
        public ObservableCollection<Bar> Bars { get; set; }
        public Foo()
        {
            Id = _nextId++;
            Name = String.Empty;
            Bars = new ObservableCollection<Bar>();
        }
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                Notify("Name");
            }
        }
        private void Notify(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
    public class Bar : INotifyPropertyChanged
    {
        static int _nextId;
        public int Id { get; private set; }
        public Bar()
        {
            Id = _nextId++;
            Name = String.Empty;
        }
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                Notify("Name");
            }
        }
        private void Notify(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }

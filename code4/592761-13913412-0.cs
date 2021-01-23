    public partial class MainWindow : Window
    {
        private static MainViewModel _mainViewModel = new MainViewModel();
        public static ObservableCollection<Employee> staff = new ObservableCollection<Employee>();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = _mainViewModel;
            dataGrid1.DataContext = staff;
            listview.DataContext = staff;
            Employee Employee1 = new Employee();
            Employee1.name = "Jeff";
            staff.Add(Employee1);
            Employee Employee2 = new Employee();
            Employee2.name = "Jefferson";
            staff.Add(Employee2);
            Employee2.name = "Tim";
        }
    }
    public class Employee
    {
        public string name { get; set; }
    }
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _SelectedEmployee;
        public string SelectedEmployee
        {
            get { return _SelectedEmployee; }
            set
            {
                _SelectedEmployee = value;
                NotifyPropertyChanged("SelectedEmployee");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

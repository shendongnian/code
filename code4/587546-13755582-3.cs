        public partial class MainWindow : Window, INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            private ObservableCollection<Employee> _employees = new ObservableCollection<Employee>();
            private Employee _selectedEmployee;
    
            public MainWindow()
            {
                InitializeComponent();
                Employees.Add(new Employee { Name = "sa_ddam213" });
            }
    
            public ObservableCollection<Employee> Employees
            { 
                get { return _employees; }
                set { _employees = value; }
            }
                
            public Employee SelectedEmployee
            {
                get { return _selectedEmployee; }
                set { _selectedEmployee = value; NotifyPropertyChanged("SelectedEmployee"); }
            }
            
          
            /// <summary>
            /// Notifies the property changed.
            /// </summary>
            /// <param name="info">The info.</param>
            public void NotifyPropertyChanged(String info)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(info));
                }
            }
        }
    
        public class Employee
        {
            public string Name { get; set; }
        }

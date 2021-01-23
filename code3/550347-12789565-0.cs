        public partial class MainWindow : Window
        {
        	public MainWindow()
        	{
        		InitializeComponent();
        
        		this.DataContext = new ViewModel(GetTestEmployees());
        	}
        
        	static IEnumerable<Employee> GetTestEmployees()
        	{
        		return new[]
        		{
        			new Employee()
        			{
        				FirstName = "Tom",
        				LastName = "Selleck",
        				Gender = Gender.Male
        			},
        			new Employee()
        			{
        				FirstName = "Pat",
        				LastName = "Sajak",
        				Gender = Gender.Male,
        			},
        			new Employee()
        			{
        				FirstName = "Mae",
        				LastName = "West",
        				Gender = Gender.Female
        			}
        		};
        	}
        }
        
        public class ViewModel : INotifyPropertyChanged
        {
        	public ViewModel(IEnumerable<Employee> employees)
        	{
        		_employees = new ObservableCollection<Employee>(employees);
        		SelectedEmployee = employees.First();
        	}
        
        	ObservableCollection<Employee> _employees;
        	public ObservableCollection<Employee> Employees
        	{
        		get { return _employees; }
        	}
        
        	Employee _selectedEmployee;
        	public Employee SelectedEmployee 
        	{
        		get { return _selectedEmployee; }
        		set
        		{
        			_selectedEmployee = value;
        			RaisePropertyChangedEvent("SelectedEmployee");
        		}
        	}
        
        	public void Next()
        	{
        		var curr = Employees.IndexOf(_selectedEmployee);
        
        		if (curr == -1) throw new ArgumentOutOfRangeException();
        
        		var next  = (curr + 1) % Employees.Count;
        
        		SelectedEmployee = Employees[next];
        	}
        
        	ICommand _nextCommand;
        	public ICommand NextCommand
        	{
        		get
        		{
        			if (_nextCommand == null)
        				_nextCommand = new NextCommand(this);
        
        			return _nextCommand;
        		}
        	}
        
        	public event PropertyChangedEventHandler PropertyChanged;
        
        	protected void RaisePropertyChangedEvent(string propertyName)
        	{
        		if (PropertyChanged != null)
        			PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        	}
        }
        
        public class NextCommand : ICommand
        {
        	ViewModel _viewModel;
        
        	public NextCommand(ViewModel viewModel)
        	{
        		_viewModel = viewModel;
        	}
        
        	public bool CanExecute(object parameter)
        	{
        		//throw new NotImplementedException();
        
        		return true;
        	}
        
        	public event EventHandler CanExecuteChanged;
        
        	public void Execute(object parameter)
        	{
        		//throw new NotImplementedException();
        
        		_viewModel.Next();
        	}
        }
        
        public class Employee
        {
        	public string FirstName { get; set; }
        	public string LastName { get; set; }
        	public Gender Gender { get; set; }
        }
        
        public enum Gender
        {
        	Male,
        	Female
        }
        
        public class GenderToColorConverter : IValueConverter
        {
        
        	public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        	{
        		var gender = (Gender)value;
        
        		if (gender == Gender.Male)
        		{
        			return Colors.Blue;
        		}
        
        		return Colors.Pink;
        	}
        
        	public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        	{
        		throw new NotImplementedException();
        	
    
    }
    }

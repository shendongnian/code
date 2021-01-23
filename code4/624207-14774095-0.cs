    public class EmployeesViewModel {
    	public Filter Filter { get; set;}
    	public ObservableCollection<Employee> Employees { get; set;}
    	public Employee SelectedEmployee { get; set;}
    	public RoutedCommand SaveSelectedEmployee { get; set;}
    	…
    }

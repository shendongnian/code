    public class YourViewModel : PropertyChangedBase
    {
    	public BindableCollection<Employee> Employees { get; set; }
    	
    	public YourViewModel
    	{
    		Employees = new BindableCollection<Employee>();
    		
    		if(Execute.InDesignMode)
    		{
    			// Add an employee when in design mode, this data will show up in design time
    			Employees.Add(new Employee 
    			{
    				Name = "Sample Data Employee"
    			});
    		}
    	}
    }

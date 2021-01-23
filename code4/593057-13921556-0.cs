    public class Employees : List<Employee>
    {
    	public new void Add(Employee employee)
    	{
    		employee.employees = this;
    		base.Add(employee);
    	}
    }

    public class EmployeeDynamicNodeProvider
    	: DynamicNodeProviderBase
    {
    	CRUDExample db = new CRUDExample();
    
    	public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
    	{
    		var result = new List<DynamicNode>();
    		
    		var employees = db.Employee;
    		foreach (var employee in employees)
    		{
    			var employeeKey = "Product_" + employee.Id.ToString();
    
    			// Create the "Details" node for the employee
    			var employeeNode = new DynamicNode(employeeKey, "EmployeeParentNodeKey", employee.Name, employee.Name, "Employee", "Details");
    			
    			// Set the "id" route value so the match will work.
    			employeeNode.RouteValues.Add("id", employee.Id);
    
    			// Add the node to the result
    			result.Add(employeeNode);
    
    
    			// Create the "Edit" node for the employee
    			var employeeEditNode = new DynamicNode("EmployeeEdit_" + employee.Id.ToString(), employeeKey, "Edit", "Edit", "Employee", "Edit");
    
    			// Set the "id" route value of the edit node
    			employeeEditNode.RouteValues.Add("id", employee.Id);
    
    			// Add the node to the result
    			result.Add(employeeEditNode);
    
    
    			// Create the "Delete" node for the employee
    			var employeeDeleteNode = new DynamicNode("EmployeeDelete_" + employee.Id.ToString(), employeeKey, "Delete", "Delete", "Employee", "Delete");
    
    			// Set the "id" route value of the delete node
    			employeeDeleteNode.RouteValues.Add("id", employee.Id);
    
    			// Add the node to the result
    			result.Add(employeeDeleteNode);
    			
    			
    			// Create the "Demographics" node for the employee
    			var employeeDemographicsNode = new DynamicNode("EmployeeDemographics_" + employee.Id.ToString(), employeeKey, "Demographics", "Demographics", "Employee", "Demographics");
    
    			// Set the "id" route value of the delete node
    			employeeDemographicsNode.RouteValues.Add("id", employee.Id);
    
    			// Add the node to the result
    			result.Add(employeeDemographicsNode);
    		}
    
    		return result;
    	}
    }

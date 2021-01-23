    public class EmployeeAddition : Form {
    
    ...
    
    public List<Employee> GetEmpList(){
        return EmployeeList;
    }
    
    ...
    
    public void ShowDisplayForm(){
        var displayForm = new DisplayForm();
        displayForm.LoadEmployees(GetEmpList());
        displayForm.Show();
    }
    
    ...
    
    }

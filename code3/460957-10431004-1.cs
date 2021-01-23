    public class Employee
    {
        //This is a method I want to call My IEmployeeService Get Method from here 
        public static Employee Get(int nEmployeeID)
        {
            return EmployeeService.Instance.Get(nEmployeeID);
        }
    }
    public class Employees
    {
        //This is a method I want to call My IEmployeeService Get Method from here 
        public static Employees Gets()
        {
            return EmployeeService.Instance.Gets();
        }
    }

    abstract class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public abstract int GetVariableBonus();
    }
    class Manager {
        public int GetVariableBonus(){
             return 2000;
        }
    }
    class Employee{
        public int GetVariableBonus(){
             return 1000;
        }
    }

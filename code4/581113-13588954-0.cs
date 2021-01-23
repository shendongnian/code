    public class Employee{
         public string Name{get;set;}
         public double Salary{get;set;}
    }
    
    public class Manager : Employee{
        public List<Employee> Manages{get;set;}
    }
    
    public class PayrollList<T> : List<T> where T:Employee{
        public void SendOutPeriodPay(){
        // Note that employee.Name and .Salary are accessible 
        // even if the list is of Manager type
            this.ForEach(employee=>PaySystem.SendPay(employee.Name,employee.Salary));
      }
    }

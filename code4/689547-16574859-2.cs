     public interface IEmployeeQuery {
         IEmployeeQuery ByLastName(string lastName);
         IEmployeeQuery ByFirstName(string firstName);
         IEmployeeQuery ByDepartment(string department);
         IEmployeeQuery ByJoinDate(Datetime joinDate);
     }

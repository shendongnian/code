    public class Employee
    {
      public int EmpId { get; set;}
      public List<string> SubjectMarks { get; set;}
    }
    var empList = (from emp in dtEmployeeList.AsEnumerable()
                   select new Employee()
                   {
                       EmpId = (int) emp["Employee"],
                       SubjectMarks = List<string>() 
                       {
                           emp["subject1"].ToString(),
                           emp["subject2"].ToString(),
                           emp["subject3"].ToString()
                       }
                   }).ToList()

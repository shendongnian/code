    public class Department 
    { 
        public int Id { get; set; } 
        public string Name { get; set; } 
        public List<Employee> employees { get; set; } 
        public Department()
        {
            employees = new List<Employee>();
        }
    } 
    foreach(Department dmt in departments)
    {
        dmt.employees.Add( new Employee () {
        
            // InterestedID = ((int)dataReader["JobId"]),
            Name = "Steve",
            Job = "Cleanup",
            Date = "Today",
         });   
    }

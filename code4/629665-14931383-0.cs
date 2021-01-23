    public class Employee
    {
        public FirstName {get; set;}
        public LastName {get; set;}
        public Address {get; set;}
    }
    List<Employee> employees = List<Employee>();
    employees.Add(new Employee{FirstName: "john", LastName: "Thunder", Address: "addr"});
    gridView1.DataSource = employees;
    gridView1.DataBind();

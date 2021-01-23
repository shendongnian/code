    public class Employee
    {
        public int ID { get; set; }
        public string Foo { get; set; }
        public void SomeMethod() { }
    }
    public class AdvancedEmployee : Employee
    {
        public string Bar { get; set; }
        public void SomeAdvMethod() { }
    }
    Employee emp = new Employee() { ID = 5, Foo = "Hello" };
    // To create a AdvancedEmployee from emp
    AdvancedEmployee advEmp = new AdvancedEmployee() { Bar = "A prop not in Emp that might need a value" }
    foreach (var p in typeof(Employee).GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(x => x.CanWrite))
        typeof(AdvancedEmployee).GetProperty(p.Name).SetValue(advEmp, p.GetValue(emp));

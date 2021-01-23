    class Program
    {
        static void Main(string[] args)
        {
            var employee = new Employee() { ID = 1, Name = "John" };
            var manager = new Manager();
            foreach (PropertyInfo propertyInfo in typeof(Employee).GetProperties())
            {
                typeof(Manager)
                    .GetProperty("Mgr" + propertyInfo.Name,
                        BindingFlags.IgnoreCase |
                        BindingFlags.Instance |
                        BindingFlags.Public)
                    .SetValue(manager,
                        propertyInfo.GetValue(employee));
            }
        }
    }
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    public class Manager
    {
        public int MgrId { get; set; }
        public string MgrName { get; set; }
    }

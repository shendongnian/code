    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                
                EmployeeCollection data = new EmployeeCollection();
                data.AddEmployee(new Employee("Apple", 25));
                data.AddEmployee(new Employee("Ball", 50));
    
                listBox1.DataSource = data;
                listBox1.DisplayMember = "Name";
            }
    
        }
    
        public class Employee
        {
            public Employee(string name, int age)
            {
                this.Name = name;
                this.Age = age;
            }
    
            public int Age
            {
                get; private set;
            }
    
            public string Name
            {
                get; private set;
            }
        }
    
        public class EmployeeCollection : System.Collections.CollectionBase
        {
            public void AddEmployee(Employee employee)
            {
                this.List.Add(employee);
            }
        }
    }

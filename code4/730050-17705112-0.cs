    class Employee
    {
        private string EmployeeName, Department;
        private int BasicSalary, HRA, DA, TA, GrossSalary;
        private double NetSalary;
        public void ReadData()
        {
            EmployeeName = Console.ReadLine();                  // I've written User
            Department = Console.ReadLine();                    // Something
            BasicSalary = Convert.ToInt32(Console.ReadLine());  // I've written 10
            HRA = Convert.ToInt32(Console.ReadLine());          // -- 61
            DA = Convert.ToInt32(Console.ReadLine());           // -- 15
            TA = Convert.ToInt32(Console.ReadLine());           // -- 6
            GrossSalary = (BasicSalary + HRA + DA + TA);        
            Console.WriteLine(GrossSalary);                     // Shows me 92
            NetSalary = GrossSalary - (GrossSalary * 0.22);
            Console.WriteLine(NetSalary);                       // Shows 71.76
        }
        class Program
        {
            static void Main(string[] args)
            {
                Employee objEmp = new Employee();
                Console.WriteLine("Enter EmpName, Department, Basicsalry, Hra, Da,Ta");
                objEmp.ReadData();
                Console.ReadLine();
            }
        }
    }

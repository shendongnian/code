        public partial class Form1 : Form
          {
            public Form1()
            {
                InitializeComponent();
            }
            private void getEmployeedata(Manager manager)
            {
                int age;
                int years;
                int salary;   
    			EmployeeListing form2;		
    
                manager.FirstName = firstnameBox.Text;
                manager.LastName = lastnameBox.Text;
                manager.Gender = genderBox.Text;
                manager.Title = titleBox.Text;
                manager.Exempt = exemptBox.Text;
    
                if (int.TryParse(ageBox.Text, out age))
                {
                    manager.Age = age;
    
                    if (int.TryParse(yearsBox.Text, out years))
                    {
                        manager.Years = years;
    
                        if (int.TryParse(salaryBox.Text, out salary))
                        {
                            manager.Salary = salary;
                        }
                        else
                        {
                            MessageBox.Show("Wrong salary input");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Wrong Years input");
                    }
                }
                else
                {
                    MessageBox.Show("Wrong age input");
                }
            }
    
        private void submitButton_Click(object sender, EventArgs e)
        {
            Manager manager = new Manager();
            getEmployeedata(manager);
    		if (form2 == null)
    		{
    			EmployeeListing form2 = new EmployeeListing();
    			form2.Show();
    		}		
            
    		form2.AddRowData(manager.FirstName, manager.LastName, manager.Gender, manager.Age, manager.Years, manager.Title, manager.Exempt, manager.Salary);
        }
    
        private void clearButton_Click(object sender, EventArgs e)
        {
            firstnameBox.Text = "";
            lastnameBox.Text = "";
            genderBox.Text = "";
            ageBox.Text = "";
            yearsBox.Text = "";
            titleBox.Text = "";
            exemptBox.Text = "";
            salaryBox.Text = "";
        }
    
    }
    
    class Employee
    {
        private string firstName = "";
        private string lastName = "";
        private string gender = "";
        private int age = 0;
        private int years = 0;
    
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
    
        }
    
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
    
        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }
    
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
    
        public int Years
        {
            get { return years; }
            set { years = value; }
        }
    
    } //end Employee class
    
    class Manager : Employee
    {
        private string title = "";
        private string exempt = "";
        private int salary = 0;
    
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
    
        public string Exempt
        {
            get { return exempt; }
            set { exempt = value; }
        }
    
        public int Salary
        {
            get { return salary; }
            set { salary = value; }
        }
    
    } //end Manager class
    
    public partial class EmployeeListing : Form
    {
        public EmployeeListing()
        {
            InitializeComponent();                                
        }
    	
    	public AddRowData(string firstname, string lastname, string gender, int age, int years, string title, string exempt, int salary)
    	{
    		employeeList.Rows.Add(firstname, lastname, gender, age, years, title, exempt, salary); 
    	}
     }

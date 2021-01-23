        // create list
        private List<Employee> payroll;
        public Form1()
        {
            InitializeComponent();
            payroll = new List<Employee>();
            // Create some employee objects
            payroll.Add(new Employee(1, "H. Potter", "Privet Drive", "201-9090"));
            payroll.Add(new Employee(2, "A. Dumbledore", "Hogewarts", "803-1230"));
            payroll.Add(new Employee(3, "R. Weasley", "The Burrow", "892-2000"));
            payroll.Add(new Employee(4, "R. Hagrid", "Hogwarts", "910-8765"));
            employeeListBox.DataSource = payroll;
            employeeListBox.DisplayMember = "Name";
        }
        private void employeeListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Employee selectedEmployee = ((sender as ListBox).SelectedItem as Employee);
            txtAddress.Text = selectedEmployee.Address;
            txtName.Text = selectedEmployee.Name;
            txtPhone.Text = selectedEmployee.PhoneNum;
        }
        private void btnCalc_Click(object sender, EventArgs e)
        {
            Employee selectedEmployee = (employeeListBox.SelectedItem as Employee);
            // Do calculations here...
        }

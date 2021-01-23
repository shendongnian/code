    private List<Employee> employees = new List<Employee>();
    
    private void ShowEmployee(Employee employee)
    {
        var item = employeeListView.Items.Add(employee.EmployeeId.ToString());
        item.SubItems.Add(employee.FirstName);
        item.SubItems.Add(employee.LastName);
        item.SubItems.Add(employee.YearSalary.ToString());
    }
    
    private void AddEmployeeButton_Click(object sender, EventArgs e)
    {
        Employee employee = new Employee();
        employee.EmployeeId = (int)idNumericUpDown.Value;
        employee.FirstName = firstNameTextBox.Text;
        employee.LastName = lastNameTextBox.Text;
        employee.YearSalary = salaryNumericUpDown.Value;
        employees.Add(employee);
        ShowEmployee(employee);
    }
    
    private void LowestSalaryButton_Click(object sender, EventArgs e)
    {
        decimal minSalary = employees.Min(em => em.YearSalary);
        MessageBox.Show(minSalary.ToString("C"), "Min salary");
    } 

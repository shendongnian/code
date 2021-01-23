    private void btnLowestSalary_Click(object sender, EventArgs e)
    {
        var minSalary = lstEmployeeData.Items.OfType<Employee>().Min(x => x.Salary);
        var empWithMaxSalary = lstEmployeeData.Items.OfType<Employee>()
                                              .First(x => x.Salary == minSalary);
        string msg = string.Format("{0} has the lowest salary of {1}", empWithMaxSalary.EmployeeFirstName, minSalary);
        MessageBox.Show(msg);
    }
     

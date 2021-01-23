    private void btnLowestSalary_Click(object sender, EventArgs e)
    {
        var minSalary = lstEmployeeData.Items.OfType<Employee>().Min(x => x.Salary);
        var empWithMinSalary = lstEmployeeData.Items.OfType<Employee>()
                                              .First(x => x.Salary == minSalary);
        string msg = string.Format("{0} has the lowest salary of {1}", empWithMinSalary.EmployeeFirstName, minSalary);
        MessageBox.Show(msg);
    }
     

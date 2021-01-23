    private void btnLowestSalary_Click(object sender, EventArgs e)
    {
        var minSalary = lstEmployeeData.Items.OfType<Employee>().Min(x => x.Salary);
        var empsWithMinSalary = lstEmployeeData.Items.OfType<Employee>()
                                               .Where(x => x.Salary == minSalary);
 
        foreach(var e in empsWithMinSalary)
        {
            string msg = string.Format("{0} has the lowest salary of {1}", e.EmployeeFirstName, minSalary);
            MessageBox.Show(msg);
        }
    }

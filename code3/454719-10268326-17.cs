    private void btnLowestSalary_Click(object sender, EventArgs e)
    {
        var minSalary = lstEmployeeData.Items.OfType<Employee>().Min(x => x.Salary);
        var empsWithMinSalary = lstEmployeeData.Items.OfType<Employee>()
                                               .Where(x => x.Salary == minSalary);
 
        string names = "";
        foreach(var e in empsWithMinSalary)
            names += Environment.NewLine + e.EmployeeFirstName;
        string msg = string.Format("The following emplyoees have the lowest salary of {0} : {1}", minSalary, names);
        MessageBox.Show(msg);
    }

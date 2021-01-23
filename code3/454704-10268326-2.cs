    private void btnSave_Click(object sender, EventArgs e)
    {
        var minSalary = lstEmployeeData.Items.OfType<Employee>().Min(x => x.Salary);
        var empWithMaxSalary = lstEmployeeData.Items.OfType<Employee>()
                                              .First(x => x.Salary == minSalary);
        // msg box show empWithMaxSalary 
    }
     

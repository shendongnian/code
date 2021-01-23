        private void btnSave_Click(object sender, EventArgs e)
        {
            var empid = Convert.ToInt32(txtEmployeeID.Text);
            var empfirstname = Convert.ToString(txtEmployeeFirstName.Text);
            var emplastname = Convert.ToString(txtEmployeeLastName.Text);
            var empsalary = Convert.ToDouble(txtSalary.Text);
            var emp = new Employee(empid, empfirstname, emplastname, empsalary);
            lstEmployeeData.Items.Add(emp);
        }

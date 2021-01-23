     private void SubmitButton_Click(object sender, EventArgs e)
        {
            if (ValidateControls()==0)
            {
               //Form is validated
            }
        }
    int ValidateControls()
    {
        int flag = 0;
        errorProvider1.Clear();
        if (txtAge.Text.Trim() == String.Empty)
        {
            errorProvider1.SetError(txtAge, "Age is required");
            flag = 1;
        }
        ............................................
        ............................................
       // validate all controls
        ............................................
        ............................................
        if (txtSalary.Text.Trim() == String.Empty)
        {
            errorProvider1.SetError(txtSalary, "Salary is required");
            flag = 1;
        }
        return flag;
    }

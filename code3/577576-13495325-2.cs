        private void btnTotal_Click(object sender, EventArgs e)
        {
            int hours = Convert.ToInt32(txtHours.Text);
            int overtime = hours - 30;
            int salary = hours * 250
            double tax = (salary + overtime) * .10;
            int deduction = salary - (300 + 400);
            if(hours > 30)
            {
                lblName.Text = txtName.Text;
                lblSalary.Text = ((overtime *120) + (salary - (deduction - tax))).ToString(); 
            }
            else
            { 
                lblSalary.Text = salary.ToString();
            }
       }

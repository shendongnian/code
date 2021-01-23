       private void tbLoanDuration_TextChanged(object sender, EventArgs e)
       {
           // Use a different name for the out parameter than your property
           // to avoid confusion
           double enteredYears = 0;
           // This is unnecessary
           Control ctrl = (Control)sender;
           if (Double.TryParse(tbLoanDuration.Text, out enteredYears))
           {
               years = enteredYears;
               errorProvider1.SetError(ctrl, "");
           }  
           else
           {
               years = 0;
               errorProvider1.SetError(ctrl, "This is not a valid number");
           }
       }

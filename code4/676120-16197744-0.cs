    private void rb30years_CheckedChanged(object sender, EventArgs e)
    {
    
        if (rb15Years.Checked)
        {
            years = 15;
            tbLoanDuration.Enabled = false;
        }
        else if (rb30Years.Checked)
        {
            years = 30;
            tbLoanDuration.Enabled = false;
        }       
        else if (rbOther.Checked)
        {
            tbLoanDuration.Enabled = true;
        }
    }

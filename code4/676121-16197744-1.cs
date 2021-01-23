    private void button1_Click(object sender, EventArgs e)
    {
        double selectedRate = 0;
        if (cbLoanRate.SelectedIndex > 1 && double.TryParse(cbLoanRate.SelectedItem, out selectedRate))
        {
            interest = selectedRate;
            lblMonthlyPayment.Text = string.Format("Your total monthly payment is {0}{1:0.00}", "$", MonthlyPayment());
        }
    }

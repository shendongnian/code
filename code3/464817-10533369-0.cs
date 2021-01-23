    double amount;
    if (double.TryParse(transactDisplay.Text.Trim(), out amount))
    {
        if (amount == 0) {
           MessageBox.Show("Please pay before proceding", "Money not paid", MessageBoxButtons.OK, MessageBoxIcon.Stop);
           return;
        }
    }
    else 
    {
       MessageBox.Show("Please add amount greater than 0.", "Money not paid", MessageBoxButtons.OK, MessageBoxIcon.Stop);
       return;
    }

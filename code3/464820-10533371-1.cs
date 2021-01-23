    double amount;
    if (double.TryParse(transactDisplay.Text, out amount) && amount > 0) {
        MessageBox.Show("Please pay before proceding", "Money not paid",
                        MessageBoxButtons.OK, MessageBoxIcon.Stop);
    }

    private void CalcStayChargesButton_Click(object sender, EventArgs e)
    {
        // Get the user input.
        int NumberOfDays;
        if (!int.TryParse(DaysInHospitalChargesTextBox.Text, out NumberOfDays))
        {
            MessageBox.Show("Please enter a whole number.");
        }
    }

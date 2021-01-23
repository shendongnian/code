    if (!string.IsNullOrWhiteSpace(txtVacate.Text))
    {
        in parsedValue = 0;
        bool isValid = int.TryParse(txtVacate.Text, out parsedValue));
        
        if (isValid) 
        {
            if (parsedValue <= 400 || parsedValue >= 500)
                MessageBox.Show("Romms provided is not vacant or does not exist at all.");
            else 
            {
                // main stuff here
            }
        }
        else 
        {
            MessageBox.Show("Please provide right info");
        }
    else
    {
        MessageBox.Show("You provide empty");
    }

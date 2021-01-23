    int parsed;
    if (int.TryParse(number.Text, out parsed) && parsed < 455)
    {
        // Logic to execute when valid
    }
    else
    {
        MessageBox.Show("Enter Value between 1 to 454");
    } 

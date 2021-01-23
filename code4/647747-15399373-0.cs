    int parsedValue;
    if (!int.TryParse(textBox.Text, out parsedValue))
    {
        MessageBox.Show("This is a number only field");
        return;
    }
    // Save parsedValue into the database

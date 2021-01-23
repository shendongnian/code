    string  myDate = myTextBox.Text;
    DateTime oldDate;
    if (!DateTime.TryParse(myDate, out oldDate))
    {
       // User entered invalid date - handle this
    }
    // oldDate is set now

    String arrival, departure;
    arrival = textBox1.Text;
    departure = textBox2.Text;
    DateTime aDate, dDate;
    if (DateTime.TryParseExact(arrival, 
                                "dd/MM/yyyy", 
                                CultureInfo.InvariantCulture, 
                                DateTimeStyles.NoCurrentDateDefault, 
                                out aDate))
    {
        MessageBox.Show("Invalid input format for Arrival Date - please enter in format DD/MM/YYYY");
    }
    if (DateTime.TryParseExact(departure, 
                                "dd/MM/yyyy", 
                                CultureInfo.InvariantCulture, 
                                DateTimeStyles.NoCurrentDateDefault, 
                                out dDate))
    {
        MessageBox.Show("Invalid input format for Departure Date - please enter in format DD/MM/YYYY");
    }
    TimeSpan dateDiff;
    dateDiff = dDate.Subtract(aDate);
    int nights = (int)dateDiff.TotalDays;
    textBox3.Text = ("" + nights);
    textBox5.Text = ("£" + (nights * 115));

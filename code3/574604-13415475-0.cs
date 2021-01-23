    DateTime aDate, dDate;
    if( DateTime.TryParseExact(arrival, "dd/mm/yyyy", null, DateTimeStyles.None, out aDate)
     && DateTime.TryParseExact(departure, "dd/mm/yyyy", null, DateTimeStyles.None, out dDate))
    {
        // ...
    }
    else{
        MessageBox.Show("Invalid input format please enter in format DD/MM/YYYY");
    }

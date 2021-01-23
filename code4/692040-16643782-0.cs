    bool res = DateTime.TryParseExact(FromDateTextBox.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out fromDate);
    if (res == false)
    {
        //date is not parsable...
    }

    var value = (object) DBNull.Value;
    DateTime parsedDate;
    if (DateTime.TryParseExact(maskedTextBox2.Text, "dd.MM.yyyy", null, 
                               DateTimeStyles.None, out parsedDate))
    {
        value = parsedDate;
    }
    prikaz.Parameters.AddWithValue("zodjdate", value);

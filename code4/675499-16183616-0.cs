    DateTime dt;
    if (DateTime.TryParseExact(txtdateofIssue.Text, "dd-MM-yyyy",
                               CultureInfo.InvariantCulture,
                               DateTimeStyles.None,
                               out dt))
    {
       dt = dt.AddDays(-1).AddYears(1);
       txtdateofExpiry.Text = dt.ToShortDateString();
    }

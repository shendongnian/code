    int from, to;
    if (int.TryParse(frA.Text, out from) && int.TryParse(toA.Text, out to))
    {
        if (to <= from)
            MessageBox.Show("To must be greater than From.");
        else
        {
            TimeSpan workingHours = TimeSpan.FromHours(to - from);
            // now you have the timespan
            int hours = workingHours.Hours;
            double minutes = workingHours.TotalMinutes;
            // ...
        }
    }
    else
        MessageBox.Show("Please enter valid hours.");

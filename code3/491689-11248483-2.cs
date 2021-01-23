    TimeSpan interval = TimeSpan.FromMinutes(15);
    for (DateTime current = openTime; current <= closeTime; current += interval)
    {
        string stringTime = current.TimeOfDay.ToString();
        ddlTime.Items.Add(new ListItem(stringTime, stringTime));
    }

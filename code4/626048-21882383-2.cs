    DateTime MyDate;
    DateTime ParsedDate;
    if (DateTime.TryParse(txtNotificationDate.Text.Trim(), out ParsedDate))
    {
        MyDate= ParsedDate;
    }
    else
    {
        MyDate = DateTime.Now;
    }

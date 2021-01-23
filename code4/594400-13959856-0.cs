    for (int n = 1; n <= 12; ++n)
    {
        MonthDropDown.Items.Add(n, DateTimeFormatInfo.CurrentInfo.GetMonthName(n));
    }
    MonthDropDown.SelectedIndex = DateTime.Now.Month;

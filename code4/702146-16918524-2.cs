    DaysOfWeek days = 0;
    if (mondayCheckbox.Checked)
        days |= DaysOfWeek.Monday;
    if (tuesdayCheckbox.Checked)
        days |= DaysOfWeek.Tuesday;
    ... And so on up to:
    if (sundayCheckbox.Checked)
        days | = DaysOfWeek.Sunday;
    if (days != 0)
    {
        RunOnDays(days);
    }
    else
    {
        // Handle no days selected.
    }

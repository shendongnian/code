    int days = 0;
    if (mondayCheckbox.Checked)
        days |= (int)DaysOfWeek.Monday;
    if (tuesdayCheckbox.Checked)
        days |= (int)DaysOfWeek.Tuesday;
    ... And so on up to:
    if (sundayCheckbox.Checked)
        days | = (int)DaysOfWeek.Sunday;
    if (days != 0)
    {
        RunOnDays((DaysOfWeek)days);
    }
    else
    {
        // Handle no days selected.
    }

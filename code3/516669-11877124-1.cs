    private DateTime? _firstDayOfWeek;
    private DateTime? _lastDayOfWeek;
    protected void yourCalendar_SelectionChanged(object sender, EventArgs e)
    {
        var selectedDate = yourCalendar.SelectedDate;
        DayOfWeek firstDay = CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
        _firstDayOfWeek = selectedDate.Date;
        while (_firstDayOfWeek.Value.DayOfWeek != firstDay)
            _firstDayOfWeek = _firstDayOfWeek.Value.AddDays(-1);
        _lastDayOfWeek = selectedDate.Date;
        while (_lastDayOfWeek.Value.DayOfWeek != _firstDayOfWeek.Value.AddDays(6).DayOfWeek)
            _lastDayOfWeek = _lastDayOfWeek.Value.AddDays(1);
    }
    protected void yourCalendar_DayRender(object sender, DayRenderEventArgs e)
    {
        if (_firstDayOfWeek.HasValue && _lastDayOfWeek.HasValue)
        {
            // There are dates to work with now, so check to see if the day falls
            // outside of the week range...
            if (e.Day.Date.Ticks < _firstDayOfWeek.Value.Ticks || e.Day.Date.Ticks > _lastDayOfWeek.Value.Ticks)
                e.Day.IsSelectable = false;
        }
    }

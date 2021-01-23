    public void AssignDates(SelectedDatesCollection dates)
    {
        if (dates.Count > 0)
        {
            // Removes today if included then adds a date 4 days from today
            DateTime today = DateTime.Today;
            if (dates.Contains(today))
            {
               dates.Remove(today);
            }
            dates.Add(today.AddDays(4));
        }
    }

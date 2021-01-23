    public void AssignDates(SelectedDatesCollection dates)
    {
        if (dates.Count > 0)
        {
            _tournamentDates.Clear();
            foreach (var date in dates)
            {                  
                _tournamentDates.Add(new DateViewModel(date));
            }
            NotifyOfPropertyChange(() => TournamentDates);
        }
    }

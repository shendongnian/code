    public IEnumerable<DateTime> UpcomingBirthdays(IEnumerable<DateTime> birthDates)
    {
        return birthDates.Select(
            bd => new DateTime( 
                ((bd.Month >= DateTime.Today.Month || (bd.Month == DateTime.Today.Month && bd.Day >= DateTime.Today.Day)) ? DateTime.Today.Year : DateTime.Today.Year + 1),
                bd.Month,
                bd.Day)
            ).OrderBy(bd => bd);
    }

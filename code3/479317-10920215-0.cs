    public IEnumerable<Record> QueryByDay(DateTime day)
    {
        return repository.Table
            .Where(t => t.MyDate.Day == day.Day && t.MyDate.Month == day.Month && t.MyDate.Year == day.Year );
    }

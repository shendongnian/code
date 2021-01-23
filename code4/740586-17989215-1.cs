    public IEnumerable<User> UsersByBirthday(IEnumerable<User> users, DateTime from, DateTime to)
    {
        var fromNormalized = NormalizeDate(from);
        var intoNormalized = NormalizeDate(into);
        return users.Where(u => fromNormalized <= NormalizeDate(u.BirthDate) && NormalizeDate(u.BirthDate) <= intoNormalized);
    }
    public int NormalizeDate(DateTime date)
    {
        return date.Month * 100 + date.Day;
    }

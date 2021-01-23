    public static LocalDate LocalDateFromWeekYearAndWeek(int weekYear,
        int weekOfWeekYear)
    {
        LocalDate midYear = new LocalDate(weekYear, 6, 1);
        LocalDate startOfWeek = midYear.Previous(IsoDayOfWeek.Monday);
        return startOfWeek.PlusWeeks(weekOfWeekYear - startOfWeek.WeekOfWeekYear);
    }

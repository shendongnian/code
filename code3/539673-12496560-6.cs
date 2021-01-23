    public static IQueryable<T> WhereDatesBetween<T>(this IQueryable<T> queryable, DateTime myDate) where T : IFromDateToDate
            {
                myDate = myDate.Date;
                return queryable.Where(m =>
                                       EntityFunctions.CreateDateTime(m.FromDate.Year, m.FromDate.Month, m.FromDate.Day, 0, 0, 0) >= myDate &&
                                       EntityFunctions.CreateDateTime(m.FromDate.Year, m.FromDate.Month, m.FromDate.Day, 0, 0, 0) <= myDate);
            }

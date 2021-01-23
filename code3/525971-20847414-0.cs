    void f1(int yyyyMMdd);
    void f2(string yyyyMMdd);
    ...
    f1(30.YearsFrom(DateTime.Today));
    f2(30.YearsFrom(DateTime.Today));
    
    ...
    public static DateAsYyyyMmDd YearsFrom(this int y, DateTime d) 
    {
        return new DateAsYyyyMmDd(d.AddYears(y));
    }
    ...
    public class DateAsYyyyMmDd
    {
        private readonly DateTime date;
        public DateAsYyyyMmDd(DateTime date)
        {
            this.date = date;
        }
        public static implicit operator int(DateOrYyyyMmDd d)
        {
            return Convert.ToInt32(d.date.ToString("yyyyMMdd"));
        }
        public static implicit operator string(DateOrYyyyMmDd d)
        {
            return d.date.ToString("yyyyMMdd");
        }
    }

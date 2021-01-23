    public class DbDateRangeAttribute
        : RangeAttribute
    {
        public DbDateRangeAttribute()
            : base(typeof(DateTime), SqlDateTime.MinValue.Value.ToShortDateString(), SqlDateTime.MaxValue.Value.ToShortDateString())
        { }
    }

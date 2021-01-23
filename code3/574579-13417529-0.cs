    [Pure]
    public static TimeSpan Seconds(this int i)
    {
        Contract.Requires(i>0);
        Contract.Ensures(Contract.Result<TimeSpan>().TotalSeconds > 0.0);
        return TimeSpan.FromSeconds(i);
    }

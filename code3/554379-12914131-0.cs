    public class RecurringProfile
    {
      private readonly DateTime _dueDate;
      private readonly TimeSpan _interval;
      public RecurringProfile(DateTime dueDate, TimeSpan interval)
      {
        _dueDate = dueDate;
        _interval = interval;
      }
      public bool IsActive { get; private set; }
      public DateTime DueDate
      {
        get { return _dueDate; }
      }
      public TimeSpan Interval
      {
        get { return _interval; }
      }
      public RecurringProfile ActivateProfile()
      {
        this.IsActive = true;
        return new RecurringProfile(this.DueDate + this.Interval, this.Interval);
      }
    }

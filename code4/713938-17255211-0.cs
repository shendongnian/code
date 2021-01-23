    public class InstanceDateHelper : IDateHelper
    {
        public DateTime PreviousOrCurrentQuarterEnd(DateTime targetDate)
        {
            return DateTimeHelper.PreviousOrCurrentQuarterEnd(targetDate);
        }
    }

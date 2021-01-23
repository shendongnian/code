    // provides a strong type when using values in memory to make sure you don't enter incorrect values
    public enum TimeSpanEnum : int
    {
        Minutes30 = 30,
        Minutes60 = 60,
    }
    public class Reminders
    {
        static Reminders()
        {
            names.Add(TimeSpanEnum.Minutes30, "30 minutes");
            names.Add(TimeSpanEnum.Minutes60, "60 minutes");
        }
        public Reminders(TimeSpanEnum ts)
        {
            if (!Enum.IsDefined(typeof(TimeSpanEnum), ts))
            {
                throw new Exception("Incorrect value given for time difference");
            }
        }
        private TimeSpanEnum value;
        private static Dictionary<TimeSpanEnum, string> names = new Dictionary<TimeSpanEnum, string>();
        public TimeSpan Difference { get { return TimeSpan.FromSeconds((int)value); } }
        public string Name { get { return names[value]; } }
    }

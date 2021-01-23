    public class Time : IEquatable<Time>
    {
        public String Hour;
        public String Minute;
        public Time()
        {
            Hour = "00";
            Minute = "00";
        }
        public Time(String hour, String minute)
            : this()
        {
            this.Hour = hour;
            this.Minute = minute;
        }
        public override int GetHashCode()
        {
            return int.Parse(Hour) * 60 + int.Parse(Minute);
        }
        public override bool Equals(object obj)
        {
            var time = obj as Time;
            return !ReferenceEquals(time, null) && Equals(time);
        }
        public bool Equals(Time time)
        {
            return string.Equals(Hour, time.Hour, StringComparison.Ordinal) && string.Equals(Minute, time.Minute, StringComparison.Ordinal);
        }
    }

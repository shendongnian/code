    public class DateTimeToStringJsonConverter : CustomJsonConverter<DateTime, string>
    {
        protected override string Convert(DateTime value)
        {
            return value.ToString();
        }
        protected override DateTime Convert(string value)
        {
            return DateTime.Parse(value);
        }
    }

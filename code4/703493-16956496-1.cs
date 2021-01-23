    public class DateTimeToStringJsonConverter : CustomJsonConverter<DateTime, string>
    {
        protected override string Convert(DateTime value)
        {
            return value.ToString();
        }
        protected override GregorianDate Convert(string value)
        {
            return DateTime.Parse(value);
        }
    }

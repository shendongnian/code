    public static class DateTimeExtensions
    {
        public static string ToStringOr(this DateTime? dateTime, string value)
        {
            return dateTime.HasValue ? dateTime.ToString() : value;
        }
    }
    // Your model
    public class Person
    {
        public DateTime? Dob { get; set; }
    }

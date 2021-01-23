    enum DurationType
    {
        [DisplayName("m")]
        Min = 1,
        [DisplayName("h")]
        Hours = 1 * 60,
        [DisplayName("d")]
        Days = 1 * 60 * 24
    }
    internal class Program
    {
        private static void Main(string[] args)
        {
            string input1 = "10h";
            string input2 = "1d10h3m";
            var x = GetOffsetFromDate(DateTime.Now, input1);
            var y = GetOffsetFromDate(DateTime.Now, input2);
        }
        private static Dictionary<string, DurationType> suffixDictionary
        {
            get
            {
                return Enum
                    .GetValues(typeof (DurationType))
                    .Cast<DurationType>()
                    .ToDictionary(duration => duration.GetDisplayName(), duration => duration);
            }
        }
        public static DateTime GetOffsetFromDate(DateTime date, string input)
        {
            MatchCollection matches = Regex.Matches(input, @"(\d+)([a-zA-Z]+)");
            foreach (Match match in matches)
            {
                int numberPart = Int32.Parse(match.Groups[1].Value);
                string suffix = match.Groups[2].Value;
                date = date.AddMinutes((int)suffixDictionary[suffix]);
            }
            return date;
        }
    }
    [AttributeUsage(AttributeTargets.Field)]
    public class DisplayNameAttribute : Attribute
    {
        public DisplayNameAttribute(String name)
        {
            this.name = name;
        }
        protected String name;
        public String Name { get { return this.name; } }
    }
    public static class ExtensionClass
    {
        public static string GetDisplayName<TValue>(this TValue value) where TValue : struct, IConvertible
        {
            FieldInfo fi = typeof(TValue).GetField(value.ToString());
            DisplayNameAttribute attribute = (DisplayNameAttribute)fi.GetCustomAttributes(typeof(DisplayNameAttribute), false).FirstOrDefault();
            if (attribute != null)
                return attribute.Name;
            return value.ToString();
        }
    }

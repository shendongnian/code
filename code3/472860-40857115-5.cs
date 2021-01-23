    public class SomeClass
    {
        public SomeClass(String date)
        {
            DateTime? tmpDate = this.TryParse(date);
            if (tmpDate.hasValue)
            {
                FromDate = tmpDate;
            }
            else
            {
                throw new ArgumentError(("Unable to parse the input string " + date));
            }
        }
        public DateTime? FromDate { get; set;}
        public DateTime? TryParse(string text)
        {
            DateTime date;
            if (DateTime.TryParse(text, out date))
            {
                return date;
            }
            else
            {
                return null;
            }
        }

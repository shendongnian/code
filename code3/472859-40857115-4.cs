    public class SomeClass
    {
        public SomeClass(String date)
        {
            DateTime tmpDate;
            DateTime.TryParse(date, out tmpDate);
            if (tmpDate != DateTime.Minvalue)
            {
                FromDate = tmpDate;
            }
            else
            {
                throw new ArgumentError(("Unable to parse the input string " + date));
            }

    public class FutureDate : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dateTime;
            var isValid = DateTime.TryParseExact(
            //Getting the value from the user.
            Convert.ToString(value),
            //We want the user to enter date in this format.
            "d mmm yyyy",
            //It checks if the culture is us-en
            CultureInfo.CurrentCulture,
            //Mosh has no idea what this does.
            DateTimeStyles.None,
            //Output parameter.
            out dateTime);
            return (isValid && dateTime > DateTime.Now);
        }
    }

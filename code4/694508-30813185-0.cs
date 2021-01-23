    /// <summary>
    /// TODO: AFTER WE UPGRADE TO .NET 4.5 THIS WILL NO LONGER BE NECESSARY.
    /// </summary>
    public class EmailAnnotation : RegularExpressionAttribute
    {
        static EmailAnnotation()
        {
            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(EmailAnnotation), typeof(RegularExpressionAttributeAdapter));
        }
        /// <summary>
        /// from: http://stackoverflow.com/a/6893571/984463
        /// </summary>
        public EmailAnnotation()
            : base(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"
                + "@"
                + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$") { }
        public override string FormatErrorMessage(string name)
        {
            return "E-mail is not valid";
        }
    }

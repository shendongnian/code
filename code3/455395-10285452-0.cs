     public sealed class DateEndAttribute : ValidationAttribute
    {
        public string DateStartProperty { get; set; }
        public override bool IsValid(object value)
        {
            // Get Value of the Date property
            string dateString = HttpContext.Current.Request[YourDateProperty];
            DateTime dateNow = DateTime.Now
            DateTime dateProperty = DateTime.Parse(dateString);
            // 
            return dateProperty < dateNow;
        }
    }

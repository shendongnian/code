    public class PhoneAreaAttribute : ValidationAttribute
    {
        public const string ValidInitNumber = "0";
        public override bool IsValid(object value)
        {
            var area = (string)value;
            if (string.IsNullOrEmpty(area))
            {
                return true;
            }
            if (area.StartsWith(PhoneAreaAttribute.ValidInitNumber))
            {
                return false;
            }
            return true;
        }
    }

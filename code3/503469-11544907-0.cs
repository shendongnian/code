    public class NoWhiteSpaceAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var strValue = value as string;
            if (!string.IsNullOrEmpty(strValue))
            {
                return !strValue.Contains(" ");
            }
            return true;
        }
    }

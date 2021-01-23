    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class ZipAttribute : System.ComponentModel.DataAnnotations.RegularExpressionAttribute
    {
        public ZipAttribute() : base("\\A\\b[0-9]{5}(?:-[0-9]{4})?\\b\\z")
        {
            ErrorMessage = "Invalid ZIP code.";
        }
    }

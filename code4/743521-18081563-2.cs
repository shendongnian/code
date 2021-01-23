    public class LocalizedRequiredAttribute : RequiredAttribute
    {
        public LocalizedRequiredAttribute() : base()
        {
        }
        public override string FormatErrorMessage(string name)
        {
            string localErrorMessage = DatabaseResourceManager.Instance.GetString(this.ErrorMessageResourceName) ?? ErrorMessage ?? "{0} is required"; //probably DataAnnotationsResources.RequiredAttribute_ValidationError would is a better option
            return string.Format(System.Globalization.CultureInfo.CurrentCulture, localErrorMessage, new object[] { name });
        }
    }

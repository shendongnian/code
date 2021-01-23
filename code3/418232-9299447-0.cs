    public enum ButtonColor
    {
        Blue = 0x1B1BE0,
        Gray = 0xBEBECC
    };
    public static class Extensions
    {
        public static MvcHtmlString Button(this HtmlHelper htmlHelper, string Value, ButtonColor buttonColor)
        {
            string renderButton = 
                string.Format(
                    @"<input type=""button"" value=""{0}"" style=""background-color: {1}"" />", 
                    Value, 
                    buttonColor.ToString()
                );
            return MvcHtmlString.Create(renderButton);
        }
    }

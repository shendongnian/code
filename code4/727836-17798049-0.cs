    class HtmlRenderer : IAttributeRenderer
    {
        public string ToString(object obj, string formatString, System.Globalization.CultureInfo culture)
        {
            if(formatString.equals("htmlTag")) {
                return HttpUtility.HtmlEncode(
                    new StringRenderer().ToString(obj, formatString, culture));
            } else {
                return obj.ToString()
            }
        }
    }

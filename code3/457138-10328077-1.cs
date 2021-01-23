    public static class HtmlExtensions
    {
        public static IHtmlString Field(this HtmlHelper html, FieldType type)
        {
            switch(field.type)
            {
                case Dropdown:
                    return html.DropDownList(... you will probably need some more info on your view model to be passed here to generate a dropdown)
                case Text:
                    return html.TextBox(...);
                case Date:
                    return html.OurDatePicker();
            }
    
            return MvcHtmlString.Empty;
        }
    }

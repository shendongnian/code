    public static class Helpers
    {
        public static IHtmlString ReadOnlyOnUpdate(this HtmlHelper helper, int BMU_ID, DatabaseOperation operation)
        {
            var attrs = new Dictionary<string, object>();
            if (operation == DatabaseOperation.Update)
            {
                attrs.Add("readonly", "readonly");
            }
            return helper.TextBox("BMU_ID", BMU_ID, attrs);
        }
    }

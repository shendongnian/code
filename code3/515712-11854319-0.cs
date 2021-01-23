    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString CheckBoxesForModel(this HtmlHelper helper,
            object model)
        {
            if (model == null)
                throw new ArgumentNullException("'model' is null");
            return CheckBoxesForModel(helper, model.GetType());
        }
        public static MvcHtmlString CheckBoxesForModel(this HtmlHelper helper,
            Type modelType)
        {
            if (modelType == null)
                throw new ArgumentNullException("'modelType' is null");
            string output = string.Empty;
            var properties = modelType.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            foreach (var property in properties)
                output += helper.CheckBox(property.Name, new { @disabled = "disabled" });
            return MvcHtmlString.Create(output);
        }
    }

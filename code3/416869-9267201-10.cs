    public static class HtmlExtensions
    {
        public static IHtmlString CheckBoxesForEnumModel<TModel>(this HtmlHelper<TModel> htmlHelper)
        {
            if (!typeof(TModel).IsEnum)
            {
                throw new ArgumentException("this helper can only be used with enums");
            }
            var sb = new StringBuilder();
            foreach (Enum item in Enum.GetValues(typeof(TModel)))
            {
                var ti = htmlHelper.ViewData.TemplateInfo;
                var id = ti.GetFullHtmlFieldId(item.ToString());
                var name = ti.GetFullHtmlFieldName(string.Empty);
                var label = new TagBuilder("label");
                label.Attributes["for"] = id;
                label.SetInnerText(item.ToString());
                sb.AppendLine(label.ToString());
                var checkbox = new TagBuilder("input");
                checkbox.Attributes["id"] = id;
                checkbox.Attributes["name"] = name;
                checkbox.Attributes["type"] = "checkbox";
                checkbox.Attributes["value"] = item.ToString();
                var model = htmlHelper.ViewData.Model as Enum;
                if (model.HasFlag(item))
                {
                    checkbox.Attributes["checked"] = "checked";
                }
                sb.AppendLine(checkbox.ToString());
            }
            return new HtmlString(sb.ToString());
        }
    }
	

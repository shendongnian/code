    public static IHtmlString CheckboxListForEnum<T>(this HtmlHelper html, string name, T modelItems) where T : struct
    {
        StringBuilder sb = new StringBuilder();
    
        foreach (T item in Enum.GetValues(typeof(T)).Cast<T>())
        {
            TagBuilder builder = new TagBuilder("input");
            long targetValue = Convert.ToInt64(item);
            long flagValue = Convert.ToInt64(modelItems);
    
            if ((targetValue & flagValue) == targetValue)
                builder.MergeAttribute("checked", "checked");
    
            builder.MergeAttribute("type", "checkbox");
            builder.MergeAttribute("value", item.ToString());
            builder.MergeAttribute("name", name);
            builder.InnerHtml = item.ToString();
    
            sb.Append(builder.ToString(TagRenderMode.Normal));
        }
    
        return new HtmlString(sb.ToString());
    }

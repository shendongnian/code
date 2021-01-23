    if (listOfValues != null)
    {
        if (!htmlAttributes.ContainsKey("id"))
        {
            htmlAttributes.Add("id", null);
        }
        foreach (SelectListItem item in listOfValues)
        {
            var id = string.Format(
                "{0}_{1}",
                metaData.PropertyName,
                item.Value
            );
            htmlAttributes["id"] = id;
            var radio = htmlHelper.RadioButtonFor(expression, item.Value, htmlAttributes).ToHtmlString();
            sb.AppendFormat(
                "{0}<label for=\"{1}\">{2}</label>",
                radio,
                id,
                HttpUtility.HtmlEncode(item.Text)
            );
        }
    }

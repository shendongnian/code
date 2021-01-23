    public static IHtmlString Test<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
    {
        Dictionary<String, Object> attributes = new Dictionary<String, Object>();
        attributes.Add("readonly", "readonly");
        PropertyInfo[] properties = htmlAttributes.GetType().GetProperties();
        foreach (PropertyInfo propertyInfo in properties)
        {
            if (propertyInfo.Name.Equals("class"))
            {
                attributes.Add("class", String.Format("{0} {1}", "readOnly", propertyInfo.GetValue(htmlAttributes, null)));
            }
            else
            {
                attributes.Add(propertyInfo.Name, propertyInfo.GetValue(htmlAttributes, null));
            }
        }
        //call the input tag
        return helper.TextBoxFor(expression, htmlAttributes);
    }

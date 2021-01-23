    public static MvcHtmlString EnumDropDownListFor<TModel, TEnum>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TEnum>> expression, string optionLabel, object htmlAttributes)
    {
        ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
        Type enumType = GetNonNullableModelType(metadata);
        IEnumerable<TEnum> values = Enum.GetValues(enumType).Cast<TEnum>();
        IEnumerable<SelectListItem> items = from value in values
                                            select new SelectListItem
                                            {
                                                Text = GetEnumDescription(value),
                                                Value = value.ToString(),
                                                Selected = value.Equals(metadata.Model)
                                            };
        // If the enum is nullable, add an 'empty' item to the collection 
        if (metadata.IsNullableValueType)
        {
            items = SingleEmptyItem.Concat(items);
        }
        return htmlHelper.DropDownListFor(expression, items, optionLabel, htmlAttributes);
    }
    public static string GetEnumDescription<TEnum>(TEnum value)
    {
        FieldInfo fi = value.GetType().GetField(value.ToString());
        DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
        if ((attributes != null) && (attributes.Length > 0))
        {
            return attributes[0].Description;
        }
        return value.ToString();
    }

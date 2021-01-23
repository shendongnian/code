    /// <summary>
    /// Returns an HTML select element for each property in the object that is represented by the specified expression using the given enumeration list items.
    /// </summary>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    /// <typeparam name="TProperty">The type of the value.</typeparam>
    /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
    /// <param name="expression">An expression that identifies the object that contains the properties to display.</param>
    /// <param name="enumType">The type of the enum that fills the drop box list.</param>
    /// <returns>An HTML select element for each property in the object that is represented by the expression.</returns>
    public static MvcHtmlString DropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
        Expression<Func<TModel, TProperty>> expression, Type enumType)
    {
        var values = from Enum e in Enum.GetValues(enumType)
                        select new { Id = e, Name = e.ToString() };
    
        return htmlHelper.DropDownListFor(expression, new SelectList(values, "Id", "Name"));
    }

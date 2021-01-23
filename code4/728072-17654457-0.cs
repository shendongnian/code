    // jonlanceley.blogspot.com/2011/06/mvc3-radiobuttonlist-helper.html
    public static MvcHtmlString RadioButtonListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
        Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> listOfValues)
    {
        var metaData = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
        var sb = new StringBuilder();
        sb.Append("<span class='RadioButtonListFor'> ");
    
        if (listOfValues != null)
        {
            // Create a radio button for each item in the list
            foreach (SelectListItem item in listOfValues)
            {
                // Generate an id to be given to the radio button field
                var id = string.Format("{0}_{1}", metaData.PropertyName, item.Value);
    
                // Create and populate a radio button using the existing html helpers
    
                var htmlAttributes = new Dictionary<string, object>();
                htmlAttributes.Add("id", id);
    
                if (item.Selected)
                    htmlAttributes.Add("checked", "checked");
    
                var radio = htmlHelper.RadioButtonFor(expression, item.Value, htmlAttributes);
    
    
                // Create the html string that will be returned to the client
                // e.g. <label<input data-val="true" data-val-required="You must select an option" id="TestRadio_1" name="TestRadio" type="radio" value="1" />Line1</label>
                sb.AppendFormat("<label>{0} {1}</label> ", radio, HttpUtility.HtmlEncode(item.Text));
            }
        }
    
        sb.Append(" </span>");
        return MvcHtmlString.Create(sb.ToString());
    }

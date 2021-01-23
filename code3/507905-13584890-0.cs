        public static MvcHtmlString CheckboxForMetro<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, int offset = 3)
        {
            TagBuilder tblabel = new TagBuilder("label");
            tblabel.AddCssClass("checkbox offset" + offset.ToString());
            TagBuilder tbinput = new TagBuilder("input");
            tbinput.Attributes.Add("type", "checkbox");
            tbinput.Attributes.Add("id", GetPropertyNameFromLambdaExpression(html, expression));
            tbinput.Attributes.Add("name", GetPropertyNameFromLambdaExpression(html, expression));
            tbinput.Attributes.Add("value", "true");
            tbinput.MergeAttributes(GetPropertyValidationAttributes(html, expression, null));
            if (GetPropertyValueFromLambdaExpression(html, expression) == "True") tbinput.Attributes.Add("checked", "checked");
            TagBuilder tbhidden = new TagBuilder("input");
            tbhidden.Attributes.Add("type", "hidden");
            tbhidden.Attributes.Add("value", "false");
            tbhidden.Attributes.Add("name", GetPropertyNameFromLambdaExpression(html, expression));
            TagBuilder tbspan = new TagBuilder("span");
            //tbspan.AddCssClass("span" + spanLabel.ToString());
            tbspan.InnerHtml = GetPropertyDisplayNameFromLambdaExpression(html, expression);
            tblabel.InnerHtml = tbinput.ToString() + tbspan.ToString() + tbhidden.ToString();
            return new MvcHtmlString(tblabel.ToString());
        }

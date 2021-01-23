        public static MvcHtmlString EditorForMany<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, IEnumerable<TValue>>> expression, string templateName = null) where TModel : class
        {
            StringBuilder sb = new StringBuilder();
            // Get the items from ViewData
            var items = expression.Compile()(html.ViewData.Model);
            var fieldName = ExpressionHelper.GetExpressionText(expression);
            var htmlFieldPrefix = html.ViewContext.ViewData.TemplateInfo.HtmlFieldPrefix;
            var fullHtmlFieldPrefix = String.IsNullOrEmpty(htmlFieldPrefix) ? fieldName : String.Format("{0}.{1}", htmlFieldPrefix, fieldName);
            int index = 0;
            foreach (TValue item in items)
            {
                // Much gratitude to Matt Hidinger for getting the singleItemExpression.
                // Current html.DisplayFor() throws exception if the expression is anything that isn't a "MemberAccessExpression"
                // So we have to trick it and place the item into a dummy wrapper and access the item through a Property
                var dummy = new { Item = item };
                // Get the actual item by accessing the "Item" property from our dummy class
                var memberExpression = Expression.MakeMemberAccess(Expression.Constant(dummy), dummy.GetType().GetProperty("Item"));
                // Create a lambda expression passing the MemberExpression to access the "Item" property and the expression params
                var singleItemExpression = Expression.Lambda<Func<TModel, TValue>>(memberExpression,
                                                                                   expression.Parameters);
                // Now when the form collection is submitted, the default model binder will be able to bind it exactly as it was.
                var itemFieldName = String.Format("{0}[{1}]", fullHtmlFieldPrefix, index++);
                string singleItemHtml = html.EditorFor(singleItemExpression, templateName, itemFieldName).ToString();
                sb.AppendFormat(singleItemHtml);
            }
            return new MvcHtmlString(sb.ToString());
        }

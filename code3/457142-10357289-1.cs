    public static class CustomHtmlHelperExtensions
    {
        public MvcHtmlString CustomControlFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel,TProperty>> memberExpression)
        {
            var member = ((MemberExpression)model.Body).Member;
            var customAttribute = member.GetAttributes().OfType<CustomAttribute>().Cast<CustomAttribute>().SingleOrDefault();
            if(customAttribute == null)
            //Perform certain logic if the property doesn't have the attribute specified
            //ex. return null;
            switch(customAttribute.FieldType)
            {
                case FieldType.TextBox: 
                    {
                        //Do something
                        return htmlHelper.TextBoxFor(memberExpression);
                    }
                default: break;
            }
            return null;
        }
    }

    public static class HtmlHelpers
    {
        public static IHtmlString Example<TModel, TProperty>(
            this HtmlHelper<TModel> html, 
            Expression<Func<TModel, TProperty>> ex
        )
        {
            var me = (ex.Body as MemberExpression);
            if (me != null)
            {
                var required = me
                    .Member
                    .GetCustomAttributes(typeof(RequiredAttribute), false)
                    .Cast<RequiredAttribute>()
                    .FirstOrDefault();
                if (required != null)
                {
                    var msg = required.FormatErrorMessage(me.Member.Name);
                    return new HtmlString(html.Encode(msg));
                }
            }
            return MvcHtmlString.Empty;
        }
    }

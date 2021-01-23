    public static class HtmlExtensions
    {
        public static IHtmlString RoleBasedTextBoxFor<TModel, TProperty>(
            this HtmlHelper<TModel> html,
            Expression<Func<TModel, TProperty>> expression,
            string roleName
        )
        {
            var user = html.ViewContext.HttpContext.User;
            if (!user.Identity.IsAuthenticated || !user.IsInRole(roleName))
            {
                // the user is not authenticated or is not in the required role
                return MvcHtmlString.Empty;
            }
            return html.TextBoxFor(expression);
        }
    }

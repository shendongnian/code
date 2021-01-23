    namespace System.Web.Mvc.Html
    {
        public static class GeneralExtensions
        {
            public static MvcHtmlString TextForInvalidField<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string text)
            {
                if(htmlHelper.ViewData.ModelState.IsValidField(htmlHelper.NameFor(expression).ToString()))
                {
                    return MvcHtmlString.Empty;
                }
                return MvcHtmlString.Create(text);            
            }
        }
    }

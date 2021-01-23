    public static class ViewPageExtensions
    {
        public static MvcHtmlString GetIdFor<TViewModel, TProperty>(ViewPage<TViewModel> viewPage, Expression<Func<TViewModel, TProperty>> expression)
        {
            return viewPage.Html.IdFor(expression);
        }
        public static MvcHtmlString FocusScript<TViewModel>(this ViewPage<TViewModel> viewPage)
        {
            if (viewPage.ViewData["FieldToFocus"] == null)
                return MvcHtmlString.Empty;
            object expression = viewPage.ViewData["FieldToFocus"];
            Type expressionType = expression.GetType(); // expressionType = Expression<Func<TViewModel, TProperty>>
            Type functionType = expressionType.GetGenericArguments()[0]; // functionType = Func<TViewModel, TProperty>
            Type[] functionGenericArguments = functionType.GetGenericArguments(); // functionGenericArguments = [TViewModel, TProperty]
            System.Reflection.MethodInfo method = typeof(ViewPageExtensions).GetMethod("GetIdFor").MakeGenericMethod(functionGenericArguments); // method = GetIdFor<TViewModel, TProperty>
            MvcHtmlString id = (MvcHtmlString)method.Invoke(null, new[] { viewPage, expression }); // Call GetIdFor<TViewModel, TProperty>(viewPage, expression);
            return MvcHtmlString.Create(
                @"<script type=""text/javascript"" language=""javascript"">
                    $(document).ready(function() {
                        setTimeout(function() {
                            $('#" + id + @"').focus();
                        }, 500);
                    });
                </script>");
        }
    }

    public static class HtmlExtensions
    {
        public static string IdFor(
            this HtmlHelper htmlHelper, 
            LambdaExpression expression
        )
        {
            var id = ExpressionHelper.GetExpressionText(expression);
            return htmlHelper.ViewData.TemplateInfo.GetFullHtmlFieldId(id);
        }
        public static MvcHtmlString FocusScript(
            this HtmlHelper htmlHelper
        )
        {
            if (htmlHelper.ViewData["FieldToFocus"] != null)
            {
                return MvcHtmlString.Create(
                @"<script type=""text/javascript"">
                    $(document).ready(function() {
                        setTimeout(function() {
                            $('#" + htmlHelper.IdFor((LambdaExpression)htmlHelper.ViewData["FieldToFocus"]) + @"').focus();
                        }, 500);
                    });
                </script>");
            }
            else
            {
                return MvcHtmlString.Empty;
            }
        }
    }

    using System;
    using System.Linq.Expressions;
    using System.Text;
    using System.Web.Mvc;
    using System.Web.Mvc.Html;
    public class HtmlHelpers
    {
        public static MvcHtmlString BootstrapFormItem<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression)
        {
            StringBuilder html = new StringBuilder("<div class=\"control-group\">");
            html.AppendLine(helper.LabelFor(expression).ToString());
            html.AppendLine("<div class=\"controls\">");
            html.AppendLine(helper.DisplayFor(expression).ToString());
            html.AppendLine(helper.ValidationMessageFor(expression).ToString());
            html.AppendLine("</div>");
            html.AppendLine("</div>");
            return MvcHtmlString.Create(html.ToString());
        }
    }

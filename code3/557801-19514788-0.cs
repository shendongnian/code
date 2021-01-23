    public static class HiddenExtensions
    {
        public static MvcHtmlString HiddenForEnumerable<TModel, TProperty>(this HtmlHelper<TModel> helper,
            Expression<Func<TModel, IEnumerable<TProperty>>> expression)
        {
            var sb = new StringBuilder();
            var membername = expression.GetMemberName();
            var model = helper.ViewData.Model;
            var list = expression.Compile()(model);
            for (var i = 0; i < list.Count(); i++)
            {
                sb.Append(helper.Hidden(string.Format("{0}[{1}]", membername, i), list.ElementAt(i)));
            }
            return new MvcHtmlString(sb.ToString());
        }
    }

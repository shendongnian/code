    public static class Test
    {
        public static Helper<TModel> MyHelper<TModel>(this HtmlHelper helper, TModel model)
        {
            return new Helper<TModel>(helper, model);
        }
    }
    public class Helper<TModel>
    {
        private readonly HtmlHelper helper;
        private readonly TModel model;
        public Helper(HtmlHelper helper, TModel model)
        {
            this.helper = helper;
            this.model = model;
        }
        public Helper<TModel> Add<TProperty>(Expression<Func<TModel, TProperty>> expression)
        {
            // TODO
            return this;
        }
        public MvcHtmlString Build()
        {
            return new MvcHtmlString("TODO");
        }
    }

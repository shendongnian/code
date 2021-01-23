    public static IHtmlString GetBytes<TModel, TValue>(this HtmlHelper<TModel> helper, System.Linq.Expressions.Expression<Func<TModel, TValue>> expression, byte[] array, string Id)
        {
            TagBuilder tb = new TagBuilder("img");
            tb.MergeAttribute("id", Id);
            var base64 = Convert.ToBase64String(array);
            var imgSrc = String.Format("data:image/gif;base64,{0}", base64);
            tb.MergeAttribute("src", imgSrc);
            return MvcHtmlString.Create(tb.ToString(TagRenderMode.SelfClosing));
        }
        

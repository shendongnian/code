    public static MvcHtmlString EnumDisplayFor<TModel, TEnum>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TEnum>> expression)
        {
            //Get the model
            TModel model = htmlHelper.ViewData.Model;
            //Compile expression as Func
            Func<TModel, TEnum> method = expression.Compile();
            //Calling compiled expression return TEnum
            TEnum enumValue = method(model);
            return MvcHtmlString.Create(GetEnumDescription(enumValue));
        }

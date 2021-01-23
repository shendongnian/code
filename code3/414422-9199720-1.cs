    public static MvcHtmlString CustomEditorFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
    {
        var idString = htmlHelper.IdFor(expression);
        var items = // get items
        
        var param = Expression.Parameter(typeof(TModel), "m");
        var member = Expression.Property(
                         Expression.Property(param, ExpressionHelper.GetExpressionText(expression))
                     , "Id");
        var isNullable = Nullable.GetUnderlyingType(member.Type);
        if (isNullable != null) {
            var expr2 = Expression.Lambda<Func<TModel, int?>>(
                            member, new[] { param }
                        );
            return htmlHelper.DropDownListFor(expr2, items, new { id = idString });
        }
        var expr = Expression.Lambda<Func<TModel, int>>(
                       member, new[] { param }
                   );
        return htmlHelper.DropDownListFor(expr, items, new { id = idString });
    }

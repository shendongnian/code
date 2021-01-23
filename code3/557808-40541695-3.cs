    public static MvcHtmlString HiddenForEnumerable<TModel, TModelProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, IEnumerable<TModelProperty>>> expression, string prefix = null)
    {
        var sb = new StringBuilder();
        var membername = expression.GetMemberName();
        var model = htmlHelper.ViewData.Model;
        var list = expression.Compile()(model);
        var type = typeof(TModelProperty);
        var memPropertyInfo = type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Where(x => x.GetSetMethod(false) != null && x.GetGetMethod(false) != null)
            .Select(x => new
            {
                Type = x.PropertyType,
                x.Name,
                Get = (Func<TModelProperty, object>)(p => x.GetValue(p, null))
            }).ToList();
        for (var i = 0; i < list.Count(); i++)
        {
            var listItem = list.ElementAt(i);
            if (memPropertyInfo.Any())
            {
                foreach (var m in memPropertyInfo)
                {
                    var inputName = $"{prefix ?? ""}{membername}[{i}].{m.Name}";
                    var inputValue = m.Get(listItem);
                    var genericArguments = m.Type.GetGenericArguments();
                    if (genericArguments.Any() && IsEnumerableType(m.Type))
                    {
                        var delegateType = typeof(Func<,>).MakeGenericType(typeof(TModel), m.Type);
                        var bodyExpression = Expression.Constant(inputValue, m.Type);
                        var paramExpression = Expression.Parameter(typeof(TModel), "model");
                        var expressionTree = Expression.Lambda(delegateType, bodyExpression, new[] { paramExpression });
                        var hiddenForEnumerableInfo = typeof(HtmlHelpers).GetMethod("HiddenForEnumerable");
                        var hiddenForEnumerable = hiddenForEnumerableInfo.MakeGenericMethod(typeof(TModel), genericArguments[0]);
                        object[] args = { htmlHelper, expressionTree, inputName };
                        sb.Append(hiddenForEnumerable.Invoke(null, args));
                    }
                    else
                    {
                        sb.Append(htmlHelper.Hidden(inputName, inputValue));
                    }
                }
            }
            else
            {
                sb.Append(htmlHelper.Hidden($"{membername}[{i}]", listItem));
            }
        }
        return new MvcHtmlString(sb.ToString());
    }
    private static string GetMemberName<TModel, T>(this Expression<Func<TModel, T>> input)
    {
        if (input == null)
            return null;
        MemberExpression memberExp = null;
        if (input.Body.NodeType == ExpressionType.MemberAccess)
            memberExp = input.Body as MemberExpression;
        else if (input.Body.NodeType == ExpressionType.Convert)
            memberExp = ((UnaryExpression)input.Body).Operand as MemberExpression;
        return memberExp?.Member.Name;
    }
    private static bool IsEnumerableType(Type type)
    {
        return (type.GetInterface("IEnumerable") != null);
    }

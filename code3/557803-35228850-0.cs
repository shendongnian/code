    public static MvcHtmlString HiddenForEnumerable<TModel, TModelProperty>(this HtmlHelper<TModel> helper,
                Expression<Func<TModel, IEnumerable<TModelProperty>>> expression, params Expression<Func<TModelProperty, object>>[] memberPropsExpressions)
    {
    	var sb = new StringBuilder();
    
    	var membername = expression.GetMemberName();
    	var model = helper.ViewData.Model;
    	var list = expression.Compile()(model);
    
    	var memPropsInfo = memberPropsExpressions.Select(x => new
    	{
    		MemberPropName = x.GetMemberName(),
    		ListItemPropGetter = x.Compile()
    	}).ToList();
    
    	for (var i = 0; i < list.Count(); i++)
    	{
    		var listItem = list.ElementAt(i);
    		if (memPropsInfo.Any())
    		{
    			foreach (var q in memPropsInfo)
    			{
    				sb.Append(helper.Hidden(string.Format("{0}[{1}].{2}", membername, i, q.MemberPropName), q.ListItemPropGetter(listItem)));
    			}
    		}
    		else
    		{
    			sb.Append(helper.Hidden(string.Format("{0}[{1}]", membername, i), listItem));
    		}
    	}
    
    	return new MvcHtmlString(sb.ToString());
    }
    public static string GetMemberName<TModel, T>(this Expression<Func<TModel, T>> input)
    {
    	if (input == null)
    		return null;
    
    	MemberExpression memberExp = null;
    
    	if (input.Body.NodeType == ExpressionType.MemberAccess)
    		memberExp = input.Body as MemberExpression;
    	else if (input.Body.NodeType == ExpressionType.Convert)
    		memberExp = ((UnaryExpression)input.Body).Operand as MemberExpression;
    
    	return memberExp != null ? memberExp.Member.Name : null;
    }

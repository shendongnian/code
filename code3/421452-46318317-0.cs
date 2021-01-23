    /// <summary>
	/// Returns an HTML hidden input element for each item in the object's property (collection) that is represented by the specified expression.
	/// </summary>
	public static IHtmlString HiddenForCollection<TModel, TProperty>(this HtmlHelper<TModel> html, Expression<Func<TModel, TProperty>> expression) where TProperty : ICollection
	{
		var model = html.ViewData.Model;
		var property = expression.Compile().Invoke(model);
		var result = new StringBuilder();
		if (property != null && property.Count > 0)
		{
			for(int i = 0; i < property.Count; i++)
			{
				var modelExp = expression.Parameters.First();
				var propertyExp = expression.Body;
				var itemExp = Expression.ArrayIndex(propertyExp, Expression.Constant(i));
				var itemExpression = Expression.Lambda<Func<TModel, object>>(itemExp, modelExp);
				result.AppendLine(html.HiddenFor(itemExpression).ToString());
			}
		}
		return new MvcHtmlString(result.ToString());
	}

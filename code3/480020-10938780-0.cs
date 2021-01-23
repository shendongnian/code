	public static class EnumerableExtensions
	{
		public static IEnumerable<SelectListItem> ToSelectList<T, TTextProperty, TValueProperty>(this IEnumerable<T> instance, Expression<Func<T, TTextProperty>> text, Expression<Func<T, TValueProperty>> value, Func<T, bool> selectedItem = null)
		{
			return instance.Select(t => new SelectListItem
			{
				Text = Convert.ToString(text.ToPropertyInfo().GetValue(t, null)),
				Value = Convert.ToString(value.ToPropertyInfo().GetValue(t, null)),
				Selected = selectedItem != null ? selectedItem(t) : false
			});
		}
		public static PropertyInfo ToPropertyInfo(this LambdaExpression expression)
		{
			MemberExpression body = expression.Body as MemberExpression;
			
			if (body != null)
			{
				PropertyInfo member = body.Member as PropertyInfo;
				if (member != null)
				{
					return member;
				}
			}
			throw new ArgumentException("Expression is not a Property");
		}
	}
    model.Roles = context.Roles.ToSelectList(r => r.RoleID, r => r.Description);

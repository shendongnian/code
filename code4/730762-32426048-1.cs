    public static class ReflectionExtensions {
		public static PropertyInfo GetProperty<TEntity, TProperty>(this Expression<Func<TEntity, TProperty>> source) {
			//TODO: check TEntity, if needed. Now it's ignored
			var member = source.Body as MemberExpression;
			if (member == null) {
				throw new ArgumentException(String.Format(
					"Expression '{0}' refers to a method, not a property.", source));
			}
			var propertyInfo = member.Member as PropertyInfo;
			if (propertyInfo == null) {
				throw new ArgumentException(string.Format(
					"Expression '{0}' refers to a field, not a property.", source));
			}
			return propertyInfo;
		}
		public static string GetPropertyName<TEntity, TProperty>(this Expression<Func<TEntity, TProperty>> source) {
			return source.GetProperty().Name;
		}
    }

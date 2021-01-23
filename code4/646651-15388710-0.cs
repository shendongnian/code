	public static class SettingsExtensions
	{
		public static T GetSettingDefaultValue<T, T2>(this T2 settings,
			Expression<Func<T2, T>> expression) where T2 : ApplicationSettingsBase
		{
			MemberExpression memberExpr = expression.Body as MemberExpression;
			return (T)settings.Properties[memberExpr.Member.Name].DefaultValue;
		}
	}

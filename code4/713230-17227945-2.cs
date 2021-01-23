    public static class EnumExtensions
	{
		public static string Description<T>(this T t)
		{
			var descriptionAttribute = (DescriptionAttribute) typeof (T).GetMember(t.ToString())
			                           .First().GetCustomAttribute(typeof (DescriptionAttribute));
			return descriptionAttribute == null ? "" : descriptionAttribute.Description;
		}
	}

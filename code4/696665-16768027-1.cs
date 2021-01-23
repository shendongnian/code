	public static class EnumExtension
	{
		/// <summary>
		/// Gets the string of an DescriptionAttribute of an Enum.
		/// </summary>
		/// <param name="value">The Enum value for which the description is needed.</param>
		/// <returns>If a DescriptionAttribute is set it return the content of it.
		/// Otherwise just the raw name as string.</returns>
		public static string Description(this Enum value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			string description = value.ToString();
			FieldInfo fieldInfo = value.GetType().GetField(description);
			DescriptionAttribute[] attributes =
			   (DescriptionAttribute[])
			 fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
			if (attributes != null && attributes.Length > 0)
			{
				description = attributes[0].Description;
			}
			return description;
		}
	}

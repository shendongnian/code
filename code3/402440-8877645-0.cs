    public static class EnumHelper
    {
        public static SelectList SelectListFor<T>(T selected) where T : struct 
        {
            Type t = typeof(T);
            if (t.IsEnum)
            {
                var values = Enum.GetValues(t).Cast<Enum>()
                                 .Select(e => new { Id = Convert.ToInt32(e), Name = e.GetDescription() });
                return new SelectList(values, "Id", "Name", Convert.ToInt32(selected));
            }
            return null;
        }
        public static string GetDescription<TEnum>(this TEnum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
			if (fi != null)
			{
				DescriptionAttribute[] attributes =
					(DescriptionAttribute[])fi.GetCustomAttributes(
						typeof(DescriptionAttribute),
						false);
				if (attributes.Length > 0)
					return attributes[0].Description;
			}
            return value.ToString();
        }
    }

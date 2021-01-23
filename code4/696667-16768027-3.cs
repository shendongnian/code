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
        /// <summary>
        /// Creates an List with all keys and values of a given Enum class
        /// </summary>
        /// <typeparam name="T">Must be derived from class Enum!</typeparam>
        /// <returns>A list of KeyValuePair&lt;Enum, string&gt; with all available
        /// names and values of the given Enum.</returns>
        public static IList<KeyValuePair<Enum, string>> ToList<T>() where T : struct
        {
			var type = typeof(T);
            if (!type.IsEnum)
            {
                throw new ArgumentException("T must be an enum");
            }
            return (IList<KeyValuePair<Enum, string>>)
                    Enum.GetValues(type)
                        .OfType<Enum>()
                        .Select(e => new KeyValuePair<Enum, string>(e, e.Description()))
                        .ToArray();
        }
		
		public static T GetValueFromDescription<T>(string description) where T : struct
		{
			var type = typeof(T);
			
			if(!type.IsEnum)
			{
				throw new ArgumentException("T must be an enum");
			}
			
			foreach(var field in type.GetFields())
			{
				var attribute = Attribute.GetCustomAttribute(field,
					typeof(DescriptionAttribute)) as DescriptionAttribute;
				if(attribute != null)
				{
					if(attribute.Description == description)
					{
						return (T)field.GetValue(null);
					}
				}
				else
				{
					if(field.Name == description)
					{
						return (T)field.GetValue(null);
					}
				}
			}
			
			throw new ArgumentOutOfRangeException("description");
			// or return default(T);
		}
    }

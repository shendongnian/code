        public static string GetDisplayValue(this Enum value)
        {
            try
            {
                var fieldInfo = value.GetType().GetField(value.ToString());
                var descriptionAttributes = fieldInfo.GetCustomAttributes(typeof(DisplayAttribute), false) as DisplayAttribute[];
                if (descriptionAttributes == null || descriptionAttributes.Length == 0) return value.ToString();
                if (descriptionAttributes[0].ResourceType != null)
                {
                    var resource = descriptionAttributes[0].ResourceType.GetProperty("ResourceManager").GetValue(null) as ResourceManager;
                    return resource.GetString(descriptionAttributes[0].Name);
                }
                else
                {
                    return descriptionAttributes[0].Name;
                }
            }
            catch
            {
                return value.ToString();
            }
        }

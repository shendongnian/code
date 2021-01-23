        public static string GetDisplayName(this Enum enumValue, CultureInfo ci)
        {
            var displayAttr = enumValue
                .GetType()
                .GetMember(enumValue.ToString())
                .First()
                .GetCustomAttribute<DisplayAttribute>();
            var resMan = displayAttr.ResourceType?.GetProperty(@"ResourceManager", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(null, null) as ResourceManager;
            return resMan?.GetString(displayAttr.Name, ci) ?? enumValue.GetName();
        }

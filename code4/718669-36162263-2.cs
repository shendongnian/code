    public class LocalizedDescriptionAttribute : Attribute
    {
        private readonly string _resourceKey;
        private readonly Type _resourceType;
        public LocalizedDescriptionAttribute(string resourceKey, Type resourceType)
        {
            _resourceType = resourceType;
            _resourceKey = resourceKey;
        }
        public string Description
        {
            get
            {
                string displayName = String.Empty;
                ResourceManager resMan = _resourceType.GetProperty(
                    @"ResourceManager", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(null, null) as ResourceManager;
                CultureInfo culture = _resourceType.GetProperty(
                        @"Culture", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(null, null) as CultureInfo;
                if (resMan != null)
                {
                    displayName = resMan.GetString(_resourceKey, culture);
                }
                var ret = string.IsNullOrEmpty(displayName) ? string.Format("[[{0}]]", _resourceKey) : displayName;
                return ret;
            }
        }
    }

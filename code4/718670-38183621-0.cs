     [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1019:DefineAccessorsForAttributeArguments", Justification ="Resourcetype is only needed to instantiate Resource manager, and ResourceManager is exposed")]
    [AttributeUsage(AttributeTargets.All)]
    public sealed class LocalizedDescriptionAttribute 
        : DescriptionAttribute
    {
        private readonly string _resourceKey;
        private readonly ResourceManager _resourceManager;
        public LocalizedDescriptionAttribute(string resourceKey, Type resourceType)
        {
            _resourceManager = new ResourceManager(resourceType);
            _resourceKey = resourceKey;
        }
        public string ResourceKey
        {
            get { return _resourceKey; }
        }
        public ResourceManager ResourceManager
        {
            get { return _resourceManager; }
        }
        public override string Description
        {
            get
            {
                string displayName = _resourceManager.GetString(_resourceKey);
                return string.IsNullOrEmpty(displayName)? string.Format(CultureInfo.CurrentUICulture ,"[[{0}]]", _resourceKey) : displayName;
            }
        }
    }
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum enumValue)
        {
            if (enumValue == null)
            {
                throw new ArgumentNullException("enumValue");
            }
            FieldInfo fi = enumValue.GetType().GetField(enumValue.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes != null && attributes.Length > 0)
            {
                return attributes[0].Description;
            }
            else
            {
                return enumValue.ToString();
            }
        }
    }

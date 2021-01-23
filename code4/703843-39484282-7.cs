    public class DisplayBizAttribute
        : LocalisedDisplayNameAttribute
    {
        public DisplayBizAttribute(string resourceName)
            : base(StringsBiz.ResourceManager, resourceName)
        {
        }
    }
    public class DisplayWebAttribute
        : LocalisedDisplayNameAttribute
    {
        public DisplayBizAttribute(string resourceName)
            : base(StringsWeb.ResourceManager, resourceName)
        {
        }
    }

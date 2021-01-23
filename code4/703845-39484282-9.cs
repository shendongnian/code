    public class DisplayBizAttribute
        : LocalisedDisplayNameAttribute
    {
        public enum Name
        {
            PhoneNumber,
            ProductName,
        }
    
        public DisplayBizAttribute(Name resourceName)
            : base(StringsBiz.ResourceManager, resourceName.ToString())
        {
        }
    }

    public enum Property
    {
        PrimaryAddress,
        SecondaryAddress,
        UsePrimaryAddress
    }
    public class ViewModel
    {
        public ViewModel()
        {
            Properties = new Dictionary<Property, object>
            {
                { Property.PrimaryAddress, "123" },
                { Property.SecondaryAddress, "456" },
                { Property.UsePrimaryAddress, true }
            };
        }
        public Dictionary<Property, object> Properties { get; private set; }
    }

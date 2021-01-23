    public class TestConventions : CompositeCustomization
    {
        public TestConventions()
            : base(
                new SettingMappingXmlCustomization(),
                new AutoMoqCustomization())
        {
        }
    }

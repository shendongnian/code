    public class SettingMappingXmlCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customize<SettingMappingXml>(
                c => c.Without(s => s.SettingKey));
        }
    }

    public class OmitExtensionDataObjectPropertyCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Register<ExtensionDataObject>(() => null);
        }
    }

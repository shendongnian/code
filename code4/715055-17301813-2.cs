    public class OmitAutoPropertiesForTypesInNamespace : ICustomization
    {
        private readonly string ns;
        public OmitAutoPropertiesForTypesInNamespace(string ns)
        {
            this.ns = ns;
        }
        public void Customize(IFixture fixture)
        {
            fixture.Customizations.Add(new OmitPropertyForTypeInNamespace(this.ns));
        } 
    }

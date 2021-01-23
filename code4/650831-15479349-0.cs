    public void Test()
    {
        var fixture = new Fixture();
        fixture.Customizations.Add(
            new PropertyTypeOmitter(
                typeof(ExtensionDataObject)));
    
        var person = fixture.CreateAnonymous<Person>();
    }
    
    internal class PropertyTypeOmitter : ISpecimenBuilder
    {
        private readonly Type type;
    
        internal PropertyTypeOmitter(Type type)
        {
            if (type == null)
                throw new ArgumentNullException("type");
    
            this.type = type;
        }
    
        internal Type Type
        {
            get { return this.type; }
        }
    
        public object Create(object request, ISpecimenContext context)
        {
            var propInfo = request as PropertyInfo;
            if (propInfo != null && propInfo.PropertyType == type)
                return new OmitSpecimen();
    
            return new NoSpecimen(request);
        }
    }

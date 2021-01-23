    public class TypeDescriptorOverridingProvider : TypeDescriptionProvider
        {
            private readonly ICustomTypeDescriptor ctd;
            
            public TypeDescriptorOverridingProvider(ICustomTypeDescriptor ctd)
            {
                this.ctd = ctd;
            }
            
            public override ICustomTypeDescriptor GetTypeDescriptor (Type objectType, object instance)
            {
                return ctd;
            }
        }

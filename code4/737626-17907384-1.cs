    public static class MetadataExtensions
    {
        private static void Register(Type type, Type associatedMetadataType)
        {
            var provider = new AssociatedMetadataTypeTypeDescriptionProvider(type, associatedMetadataType);
            TypeDescriptor.AddProviderTransparent(provider, type);
        }
    
        public static void Register()
        {
            Register(typeof(Student), typeof(StudentMetadata));
        }
    }

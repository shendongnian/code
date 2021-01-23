        [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
        public class ApplyDisplayForUserTypeAttribute : Attribute, IMetadataAware
        {
            private readonly string _property;
            public ApplyDisplayForUserTypeAttribute(string property)
            {
                this._property = property;
            }
    
            public void OnMetadataCreated(ModelMetadata metadata)
            {
                var attribues = GetCustomAttributes(metadata.ContainerType
                                                            .GetProperty(this._property), typeof(DisplayForUserTypeAttribute))
                                                            .OfType<DisplayForUserTypeAttribute>().ToArray();
                foreach (var displayForUserTypeAttribute in attribues)
                {
                    displayForUserTypeAttribute.OnMetadataCreated(metadata);
                }
            }
        }

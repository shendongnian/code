            protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
            {
                IList<JsonProperty> properties = base.CreateProperties(type, memberSerialization);
                if (viewMode == ViewModeEnum.UnregisteredCustomer)
                {
                    properties = properties.Where(p => Attribute.IsDefined(p.DeclaringType.GetProperty(p.PropertyName), typeof(UnregisteredCustomerAttribute))).ToList();
                }
    
                return properties;
            }

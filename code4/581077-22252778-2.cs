    protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
    {
        JsonProperty property = base.CreateProperty(member, memberSerialization);
        if (viewMode == ViewModeEnum.UnregisteredCustomer && member.GetCustomAttributes(typeof(UnregisteredCustomerAttribute), true).Length == 0)
        {
            property.ShouldSerialize = instance => { return false; };
        }
            
        return property;
    }

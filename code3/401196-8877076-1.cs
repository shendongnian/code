    class InterfaceContractResolver : DefaultContractResolver
    {
        public InterfaceContractResolver() : this(false) { }
        public InterfaceContractResolver(bool shareCache) : base(shareCache) { }
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);
            var interfaces = member.DeclaringType.GetInterfaces();
            foreach (var @interface in interfaces)
            {
                foreach (var interfaceProperty in @interface.GetProperties())
                {
                    // This is weak: among other things, an implementation 
                    // may be deliberately hiding an interface member
                    if (interfaceProperty.Name == member.Name && interfaceProperty.MemberType == member.MemberType)
                    {
                        if (interfaceProperty.GetCustomAttributes(typeof(JsonIgnoreAttribute), true).Any())
                        {
                            property.Ignored = true;
                            return property;
                        }
                        if (interfaceProperty.GetCustomAttributes(typeof(JsonPropertyAttribute), true).Any())
                        {
                            property.Ignored = false;
                            return property;
                        }
                    }
                }
            }
            return property;
        }
    }

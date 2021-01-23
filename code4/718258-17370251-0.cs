    class CustomContractResolver : DefaultContractResolver
    {
        protected override JsonConverter ResolveContractConverter (Type objectType)
        {
            if (typeof(Foo).IsAssignableFrom(objectType))
                return null; // pretend converter is not specified
            return base.ResolveContractConverter(objectType);
        }
    }

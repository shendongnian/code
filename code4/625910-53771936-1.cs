    public class FooTypeConverter<T> : TypeConverter { ... }
    public class FooTypeDescriptor : CustomTypeDescriptor
    {
        private Type objectType;
        public FooTypeDescriptor(Type objectType)
        {
            this.objectType = objectType;
        }
        public override TypeConverter GetConverter()
        {
            var type = this.objectType;
            var genericArg = type.GenericTypeArguments[0];
            var converterType = typeof(FooTypeConverter<>).MakeGenericType(genericArg);
            var converter = (TypeConverter)Activator.CreateInstance(converterType);
            return converter;
        }
    }
    public class FooTypeDescriptionProvider : TypeDescriptionProvider
    {
        public override ICustomTypeDescriptor GetTypeDescriptor(Type objectType, object instance)
        {
            return new FooTypeDescriptor(objectType);
        }
    }

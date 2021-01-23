        public class GenericType : MarkupExtension
        {
            public GenericType() { }
    
            public GenericType(Type baseType, params Type[] innerTypes)
            {
                BaseType = baseType;
                InnerTypes = innerTypes;
            }
    
            public Type BaseType { get; set; }
       
            public Type[] InnerTypes { get; set; }
    
            public override object ProvideValue(IServiceProvider serviceProvider)
            {
                Type result = BaseType.MakeGenericType(InnerTypes);
                return result;
            }
        }

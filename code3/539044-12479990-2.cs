    [MarkupExtensionReturnType(typeof (IEnumerable))]
    public class EnumValuesExtension : MarkupExtension {
        
        public EnumValuesExtension() {}
    
        public EnumValuesExtension(Type enumType) 
        {
            this.EnumType = enumType;
        }
    
        [ConstructorArgument("enumType")]
        public Type EnumType { get; set; }
        
        public override object ProvideValue(IServiceProvider serviceProvider) 
        {
            if (this.EnumType == null)
                throw new ArgumentException("The enum type is not set");
                
            var converter = TypeDescriptor.GetConverter(this.EnumType);
            if (converter != null && converter.GetStandardValuesSupported(this.EnumType))        
                return converter.GetStandardValues(this.EnumType);
                        
            return Enum.GetValues(this.EnumType);
        }
    }

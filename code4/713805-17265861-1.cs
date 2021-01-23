     public class StringTypeConverter : ITypeConverter<string, Type>
    {
        public Type Convert(ResolutionContext context)
        {
            return Type.GetType(context.SourceValue.ToString());
        }
    }
    public class StringIntConverter : ITypeConverter<string, int>
    {
        public int Convert(ResolutionContext context)
        {
            return Int32.Parse(context.SourceValue.ToString());
        }
    }

    public class StringToIntTypeConverter : ITypeConverter<string, int>
    {
        public int Convert(ResolutionContext context)
        {
            int result;
            if (!int.TryParse(context.SourceValue.ToString(), out result))
            {
                result = -1;
            };
            return result;
        }
    }

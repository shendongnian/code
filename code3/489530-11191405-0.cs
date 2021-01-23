    public class TagToStringConverter : ITypeConverter<Tag, String>
    {
        public string Convert(ResolutionContext context)
        {
            return (context.SourceValue as Tag).Name ?? string.Empty;
        }
    }

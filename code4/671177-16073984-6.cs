    public class NullableIntResolver : IValueResolver
    {
        public bool AllowOverrides { get; set; }
        
        public NullableIntResolver(bool allowOverrides)
        {
            AllowOverrides = allowOverrides;
        }
        
        public ResolutionResult Resolve(ResolutionResult source)
        {
            // Add validation for source and destination types
            return source.New(
                       ResolveCore((int?) source.Value,
                                   DestinationMemberValue(source.Context)),
                       typeof(int?));
        }
        
        public int? ResolveCore(int? source, int? destination)
        {
            if (destination.HasValue && !AllowOverrides)
                return destination;
            else
                return source;
        }
        private int? DestinationMemberValue(ResolutionContext context)
        {
            var destObject = context.DestinationValue;
            var destMemberName = context.MemberName;
            return (int?) destObject
                              .GetType()
                              .GetProperty(destMemberName)
                              .GetValue(destObject, null);
        }
    }

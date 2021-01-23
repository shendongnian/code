	public class NullableIntConverter : ITypeConverter<int?, int?>
	{
		private bool AllowOverrides { get; set;}
		
		public NullableIntConverter(bool allowOverrides)
		{
			AllowOverrides = allowOverrides;
		}
		
		public int? Convert(ResolutionContext context)
		{
			var source = context.SourceValue as int?;
			var destination = context.DestinationValue as int?;
			if (destination.HasValue && !AllowOverrides)
				return destination;
			else
				return source;
		}
	}

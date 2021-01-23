    public class ConverterFactory : IConverterFactory
	{
		private readonly IResolutionRoot resolutionRoot;
		
		public ConverterFactory(IResolutionRoot resolutionRoot)
		{
			this.resolutionRoot = resolutionRoot;
		}
		
		public IConverter<TValue, TConverted> CreateConverter()
		{
			Type converterType = typeof(IConverter<,>).MakeGenericType(typeof(TValue), typeof(TConverted));
			return this.resolutionRoot.Get(converterType);
		}
	}

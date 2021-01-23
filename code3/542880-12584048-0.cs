	public class ClassIAmTesting
	{
		private readonly IRuntimeConfiguration _runtimeConfig;
		public ClassIAmTesting(IRuntimeConfiguration runtimeConfig)
		{
			_runtimeConfig = runtimeConfig;
		}
		public void MethodIWantToTest()
		{
			if(_runtimeConfig.IsDebug)
				return;
			// …
		}
	}
	public interface IRuntimeConfiguration
	{
		bool IsDebug { get; }
		bool IsUsingEmulator { get; }
	}
	public class RuntimeConfiguration : IRuntimeConfiguration
	{
		public bool IsDebug
		{
			get
			{
				return
    #if DEBUG
					true;
    #else
					false;
    #endif
			}
		}
		// repeat for IsUsingEmulator
	}

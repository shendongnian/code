	public class ForcedImplementationSelector<TService> : IHandlerSelector
	{
		private static Dictionary<Type, Type>  _forcedImplementation = new Dictionary<Type, Type>();
		public static void ForceTo<T>() where T: TService
		{
			_forcedImplementation[typeof(TService)] = typeof(T);
		}
		public static void ClearForce()
		{
			_forcedImplementation[typeof(TService)] = null;
		}
		public bool HasOpinionAbout(string key, Type service)
		{
			return service == typeof (TService);
		}
		public IHandler SelectHandler(string key, Type service, IHandler[] handlers)
		{
			var tService = typeof(TService);
			if (_forcedImplementation.ContainsKey(tService) && _forcedImplementation[tService] != null)
			{
				return handlers.FirstOrDefault(handler => handler.ComponentModel.Implementation == _forcedImplementation[tService]);
			}
			// return default
			return handlers[0];
		}
	}

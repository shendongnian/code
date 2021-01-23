	public class SomeClass<TResponse> where TResponse : IResponse
	{
		private static Dictionary<Type, List<IResponseHandler<TResponse>>> _handlerMap;
		public static void AddResponseHandler(IResponseHandler<TResponse> handler) 
		{
			List<IResponseHandler<TResponse>> handlers;
			_handlerMap.TryGetValue(typeof(TResponse), out handlers);
			if (handlers == null)
			{
				handlers = new List<IResponseHandler<TResponse>>();
				_handlerMap.Add(typeof(TResponse), handlers);
			}
			handlers.Add(handler);
		}		
	}

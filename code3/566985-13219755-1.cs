	class RequestResponseFactory : IRequestResponseFactory
	{
		private readonly Dictionary<Type, Type> _requestHandlerTypes;
		public RequestResponseFactory()
		{
			_requestHandlerTypes =
				typeof(RequestResponseFactory).Assembly.GetTypes()
					.Where(t => !t.IsAbstract)
					.Select(t => new
					{
						HandlerType = t,
						RequestType = GetHandledRequestType(t)
					})
					.Where(x => x.RequestType != null)
					.ToDictionary(
						x => x.RequestType,
						x => x.HandlerType
					);
		}
		private static Type GetHandledRequestType(Type type)
		{
			var handlerInterface = type.GetInterfaces()
				.FirstOrDefault(i =>
					i.IsGenericType &&
					i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>));
			return handlerInterface == null ? null : handlerInterface.GetGenericArguments()[0];
		}
		public TResponse ProcessRequest<TRequest, TResponse>(TRequest request) where TRequest : IRequestData<TResponse>
		{
			if (!_requestHandlerTypes.ContainsKey(typeof(TRequest)))
				throw new ApplicationException("No handler registered for type: " + typeof(TRequest).FullName);
			var handlerType = _requestHandlerTypes[typeof(TRequest)];
			var handler = (IRequestHandler<TRequest, TResponse>)Activator.CreateInstance(handlerType);
			return handler.ProcessRequest(request);
		}
	}

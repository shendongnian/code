	builder.RegisterType<ErrorHandlerAttribute>().As<IExceptionFilter>()
		.SingleInstance();
	builder.RegisterType<ErrorHandlerAttribute>().As<IExceptionFilter>()
		.WithProperties(new List<NamedPropertyParameter> { new NamedPropertyParameter("ExceptionType", typeof(UnauthorizedAccessException)), new NamedPropertyParameter("View", "UnauthorizedAccess") })
		.SingleInstance();
	builder.RegisterType<ErrorHandlerAttribute>().As<IExceptionFilter>()
		.WithProperties(new List<NamedPropertyParameter> { new NamedPropertyParameter("ExceptionType", typeof(NotImplementedException)), new NamedPropertyParameter("View", "UnderConstruction") })
		.SingleInstance();

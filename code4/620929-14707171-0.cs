    Bind<IEventViewModel>().To<EventViewModel>().DefinesNamedScope("Event");
    Bind<IEventChild>().To<EventChild>().InNamedScope("Event");
    Bind<Ninject.Extensions.Logging.ILogger>().To<EventWideLogger>().WhenInNamedScope("Event").InNamedScope("Event");
    public static class WhenEx
    {
        public static IBindingInNamedWithOrOnSyntax<T> WhenInNamedScoped<T>(this IBindingWhenSyntax<T> binding, string scopeName)
        {
            return binding.When(req => req.IsInNamedScope(scopeName));
        }
        public static bool IsInNamedScope(this IRequest req, string scopeName)
        {
            if (req.ParentContext != null && req.ParentContext.Parameters.OfType<NamedScopeParameter>().SingleOrDefault(parameter => parameter.Name == scopeName) != null)
                return true;
            return req.ParentRequest != null && req.ParentRequest.IsInNamedScope(scopeName);
        }
    }

    namespace Web.Services
    {
        public class X
        {
            private readonly Func<string, IPFormDataStrategy> _strategyResolver;
            public X(Func<string, IPFormDataStrategy> strategyResolver)
            {
                _strategyResolver = strategyResolver;
            }
            public bool AddForm(XmlDocument form, string formName)
            {
                return _strategyResolver(formName).DoWork(form);
            }
        }
    }

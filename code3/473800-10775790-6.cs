    using System;
    using System.Reflection;
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(AppDomain.CurrentDomain.FriendlyName);
            Console.WriteLine(Parameters.GetValue(""));
            Console.Read();
        }
    }
    static class Parameters
    {
        private static IParameterProvider _provider;
        static Parameters()
        {
            if (AppDomain.CurrentDomain.IsDefaultAppDomain())
            {
                _provider = new ParameterProviderProxy(AppDomain.CreateDomain(Guid.NewGuid().ToString()));
            }
            else
            {
                // Breakpoint here to see the non-default AppDomain pick an implementation.
                _provider = new NonDefaultParameterProvider();
            }
        }
        public static object GetValue(string name)
        {
            return _provider.GetValue(name);
        }
    }
    interface IParameterProvider
    {
        object GetValue(string name);
    }
    class CrossDomainParameterProvider : MarshalByRefObject, IParameterProvider
    {
        public object GetValue(string name)
        {
            return Parameters.GetValue(name);
        }
    }
    class NonDefaultParameterProvider : IParameterProvider
    {
        public object GetValue(string name)
        {
            return AppDomain.CurrentDomain.FriendlyName;
        }
    }
    class ParameterProviderProxy : IParameterProvider
    {
        private IParameterProvider _remoteProvider;
        public ParameterProviderProxy(AppDomain containingDomain)
        {
            _remoteProvider = (IParameterProvider)(CrossDomainParameterProvider)containingDomain.CreateInstanceAndUnwrap(
                Assembly.GetExecutingAssembly().FullName,
                typeof(CrossDomainParameterProvider).FullName);
        }
        public object GetValue(string name)
        {
            return _remoteProvider.GetValue(name);
        }
    }

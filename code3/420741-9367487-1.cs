    public delegate object VariableParamFactoryFunc(params object[] constructorParams);
    public class Factory
    {
        private Dictionary<Type, VariableParamFactoryFunc> _registeredTypes = new Dictionary<Type, VariableParamFactoryFunc>();
        public void RegisterType<T>(VariableParamFactoryFunc factoryFunc)
        {
            _registeredTypes.Add(typeof(T), factoryFunc);
        }
        public T Resolve<T>(params object resolutionParams)
        {
            VariableParamFactoryFunc factoryFunc;
            if (_registeredTypes.TryGetValue(typeof(T), out factoryFunc))
            {
                return (T)factoryFunc();
            }
            else
            {
                return default(T);
            }
        }
    }

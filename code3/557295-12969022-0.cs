    public class Instantiator<T> where T : new()
    {
        private T instance;
        private IDictionary<string, PropertyInfo> properties;
    
        private Action<PropertyInfo, object, object, object> _fncSetValue;
    
        public Instantiator()
        {
            Type type = typeof(T);
            properties = type.GetProperties()
                             .GroupBy(p => p.Name)
                             .ToDictionary(g => g.Key, g => g.ToList().First());
    
            var types = new Type[] { typeof(object), typeof(object),
                                     typeof(object[]) };
            var miSetValue = typeof(PropertyInfo).GetMethod("SetValue", types);
            _fncSetValue = SetValueMethod<PropertyInfo>(miSetValue);
        }
    
        public void CreateNewInstance()
        {
            instance = new T();
        }
    
        public void SetValue(string pPropertyName, object pValue)
        {
            if (pPropertyName == null) return;
            PropertyInfo property;
            if (!properties.TryGetValue(pPropertyName, out property)) return;
            TypeConverter tc = TypeDescriptor.GetConverter(property.PropertyType);
    
            var value = tc.ConvertTo(pValue, property.PropertyType);
            _fncSetValue(property, instance, value, null);
        }
    
        public T GetInstance()
        {
            return instance;
        }
    
        private static Action<G, object, object, object> SetValueMethod<G>(MethodInfo pMethod) where G : class
        {
            var miGenericHelper = 
                typeof(Instantiator<T>).GetMethod("SetValueMethodHelper", 
                                                  BindingFlags.Static | 
                                                  BindingFlags.NonPublic);
            var parameters = pMethod.GetParameters();
            var miConstructedHelper = miGenericHelper.MakeGenericMethod(typeof(G), 
                                          parameters[0].ParameterType,
                                          parameters[1].ParameterType,
                                          parameters[2].ParameterType);
            var retVal = miConstructedHelper.Invoke(null, new object[] { pMethod });
            return (Action<G, object, object, object>) retVal;
        }
    
        private static Action<TTarget, object, object, object> SetValueMethodHelper<TTarget, TParam1, TParam2, TParam3>(MethodInfo pMethod) where TTarget : class
        {
            var func = (Action<TTarget, TParam1, TParam2, TParam3>)Delegate.CreateDelegate(typeof(Action<TTarget, TParam1, TParam2, TParam3>), pMethod);
            Action<TTarget, object, object, object> retVal = (target, param1, param2, param3) => func(target, (TParam1) param1, (TParam2) param2, (TParam3) param3);
            return retVal;
        }
    }

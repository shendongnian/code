    public class Base {
        static Dictionary<Type, Object> _Singletones = new Dictionary<Type, Object>();
        public static virtual T GetInstance<T>() where T : class {
            Type t = typeof(T);
            if (_Singletones.ContainsKey(t))
                 return _Singletones[t] as T;
            else {
                // Create instance by calling private constructor and return it
                T result = Activator.CreateInstance(t, true) as T;
                _Singletones.Add(t, result);
                return result;
            }
        }
    }

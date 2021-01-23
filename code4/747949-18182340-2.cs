    class Test<T> where T : struct, IConvertible
    {
        public static Dictionary<Type, Tuple<Delegate, Delegate>> HandledTypes = new Dictionary<Type, Tuple<Delegate, Delegate>>();
        public static T TestFunction(T x)
        {
            Tuple<Delegate, Delegate> converters;
            Func<T, int> conv1;
            Func<int, T> conv2;
            if (!HandledTypes.TryGetValue(typeof(T), out converters))
            {
                var par = Expression.Parameter(typeof(T));
                var conv1e = Expression.Convert(par, typeof(int));
                conv1 = Expression.Lambda<Func<T, int>>(conv1e, par).Compile();
                var par2 = Expression.Parameter(typeof(int));
                var conv2e = Expression.Convert(par2, typeof(T));
                conv2 = Expression.Lambda<Func<int, T>>(conv2e, par2).Compile();
                HandledTypes[typeof(T)] = Tuple.Create((Delegate)conv1, (Delegate)conv2);
            }
            else
            {
                conv1 = (Func<T, int>)converters.Item1;
                conv2 = (Func<int, T>)converters.Item2;
            }
            int v = conv1(x);
            T v2 = conv2(v);
            return v2;
        }
    }

    class CuriouslyRecursiveBase<T>
    {
        public static void InstantiateDerived()
        {
            T instance = (T)Activator.CreateInstance(typeof(T));
        }
    }

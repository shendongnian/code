        public static void Init<T>(this IList<T> array )
        {
            if (array == null) return;
            for (int i = 0; i < array.Count; i++)
                array[i] = Activator.CreateInstance<T>();
        }

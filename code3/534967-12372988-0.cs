        public static class Extensions
        {
            public static Queue<T> SetFirstTo<T>(this Queue<T> q, T value)
            {
                T[] array = q.ToArray();
                array[0] = value;
                return new Queue<T>(array);
            }
        }

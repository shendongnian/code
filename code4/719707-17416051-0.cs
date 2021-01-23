    class Contains<T>
    {
        public bool Value { get; set; }
        public Contains(T[] items, T item)
        {
            Value = (bool)(typeof(Enumerable).GetMethods()
                                             .Where(x => x.Name.Contains("Contains"))
                                             .First()
                                             .MakeGenericMethod(typeof(T))
                                             .Invoke(items, new object[] { items, item }));
        }
    }

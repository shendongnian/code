    class Where<T>
    {
        public object Value { get; set; }
        public Where(T[] items, T[] items2)
        {
            Value = typeof(Enumerable).GetMethods()
                                      .Where(x => x.Name.Contains("Where"))
                                      .First()
                                      .MakeGenericMethod(typeof(T))
                                      .Invoke(items2, new object[] { items2, new Func<T, bool>(i => new Contains<T>(items, i).Value) });
        }
    }

    class Where
    {
        public object Value { get; set; }
        public Where(object[] items, object[] items2)
        {
            Value = typeof(Enumerable).GetMethods()
                                      .Where(x => x.Name.Contains("Where"))
                                      .First()
                                      .MakeGenericMethod(typeof(object))
                                      .Invoke(items2, new object[] { items2, new Func<object, bool>(i => new Contains(items, i).Value) });
        }
    }

    class ToList<T>
    {
        public List<T> Value { get; set; }
        public ToList(object where)
        {
            Value = typeof(Enumerable).GetMethods()
                                      .Where(x => x.Name.Contains("ToList"))
                                      .First()
                                      .MakeGenericMethod(typeof(T))
                                      .Invoke(where, new object[] { where }) as List<T>;
        }
    }

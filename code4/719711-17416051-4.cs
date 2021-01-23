    class Contains
    {
        public bool Value { get; set; }
        public Contains(object[] items, object item)
        {
            Value = (bool)(typeof(Enumerable).GetMethods()
                                             .Where(x => x.Name.Contains("Contains"))
                                             .First()
                                             .MakeGenericMethod(typeof(object))
                                             .Invoke(items, new object[] { items, item }));
        }
    }

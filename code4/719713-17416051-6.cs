    class ToList
    {
        public List<object> Value { get; set; }
        public ToList(object[] items, object[] items2)
        {
            var where = new Where(items, items2).Value;
            Value = (typeof(Enumerable).GetMethods()
                                      .Where(x => x.Name.Contains("ToList"))
                                      .First()
                                      .MakeGenericMethod(typeof(object))
                                      .Invoke(where, new object[] { where })) as List<object>;
        }
    }

    class SubMemberModified<T>
    {
        public T Value { get; set; }
        public SubMemberModified(object source, string property1, string property2)
        {
            var propertyValue = source.GetType()
                                      .GetProperty(property1)
                                      .GetValue(source, null);
            Value = (T)propertyValue.GetType()
                                    .GetProperty(property2)
                                    .GetValue(propertyValue, null);
        }
    }

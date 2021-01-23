    class SubMember<T>
    {
        public T Value { get; set; }
        public SubMember(object source, string field, string property)
        {
            var fieldValue = source.GetType()
                                   .GetField(field)
                                   .GetValue(source);
            Value = (T)fieldValue.GetType()
                                 .GetProperty(property)
                                 .GetValue(fieldValue, null);
        }
    }

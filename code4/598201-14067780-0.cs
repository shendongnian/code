    public IEnumerable<T> ApplyFilter(string propertyName, EnumOperator op, object value)
    {
        foreach (T item in sourceList)
        {
            object propertyValue = GetPropertyValue(item, propertyName);
            if (ApplyOperator(item, propertyValue, op, value)
            {
                yield return item;
            }
        }
    }
    private object GetPropertyValue(object item, string propertyName)
    {
        PropertyInfo property = item.GetType().GetProperty(propertyName);
        //TODO handle null
        return property.GetValue();
    }
    private bool ApplyOperator(object propertyValue, EnumOperator op, object value)
    {
        switch (op)
        {
            case EnumOperator.Equals:
                return propertyValue.Equals(value);
            //TODO other operators
            default:
                throw new UnsupportedEnumException(op);
        }
    }

    public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
    {
        // get the current property value
        string value = (string)context.PropertyDescriptor.GetValue(context.Instance);
        return new StandardValuesCollection(GetFilteredList(value));
    }

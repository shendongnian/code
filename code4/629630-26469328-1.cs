    public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
    {
        StandardValuesCollection svc;
        if (context.PropertyDescriptor.Name == "Bounds")
            svc = new StandardValuesCollection(LSValues1);
        else if (context.PropertyDescriptor.Name == "Rounds")
            svc = new StandardValuesCollection(LSValues2);
        return svc;
    }

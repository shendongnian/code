    public override bool CompileTimeValidate(Type type)
    {
        if (!type.IsImplementationOf(typeof(IFaultConverterProvider )))
        {
            // The aspect must be in a type which implements IFaultConverterProvider 
            Message.Write(
                MessageLocation.Of(type),
                SeverityType.Error,
                "CUSTOM02",
                "Cannot apply [MyFaultExceptionAspect] to type {0} because it does not implement IFaultConverterProvider .", type);
                return false;
        }
        return true;
    }

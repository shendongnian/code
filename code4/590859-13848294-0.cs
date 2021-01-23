    public override void OnException(MethodExecutionArgs args)
    {
        IFaultConverterProvider provider = args.Instance as IFaultConverterProvider;
        if (null != provider)
            Func<Exception, FaultException>exceptionConverterFunc = provider.GetFunc();
    }

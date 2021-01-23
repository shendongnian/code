    public T ChooseType<T>(RetType how)
    {
        switch (how)
        {
            case RetType.RetInt:
                return (dynamic)int.Parse(paramValue);
            case RetType.RetBool:
                return (dynamic)Boolean.Parse(paramValue);
            case RetType.RetString:
                return (dynamic)paramValue;
            default:
                throw new ArgumentException("RetType not supported", "how");
        }
    }

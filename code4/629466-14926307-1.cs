    public ISingleResult<string> PFOValidateUpdateData(...)
    {
        IExecuteResult result = this....;
        return (ISingleResult<string>)result.ReturnValue;
    }
    
    var products = PFOValidateUpdateData(...).ToList();

    [Function(Name = "GetDate", IsComposable = true)]
    public System.DateTime GetServerDate()
    {
        return ((System.DateTime)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod()))).ReturnValue));
    }

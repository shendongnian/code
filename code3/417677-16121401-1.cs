    [AcceptVerbs(HttpVerbs.Get)]
    public virtual NJsonResult GetData()
    {
        var data = ...
        return new NJsonResult(data);
    }

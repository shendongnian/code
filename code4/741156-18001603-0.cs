    [HttpGet]
    public string GetDependents()
    {
        Dependent[] dependents = GetAllDependents();
        return new JavaScriptSerializer().Serialize(dependents);
    }

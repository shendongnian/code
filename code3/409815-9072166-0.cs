    Func<Parameter, bool> matchesCondition = p => p.Condition;
    foreach(var parameter in parameters)
    {
        if(matchesCondition(parameter))
        {
            ...
        }
    }

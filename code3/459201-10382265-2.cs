    public EvaluateAttribute(params Type[] accessEvaluators)
    {
        foreach (var type in accessEvaluators)
        {
            if (!typeof(IAccessEvaluator).IsAssignableFrom(type))
            {
                throw new InvalidOperationException("Suppied type must be of type IAccessEvaluator");
            }
        }
        _accessEvaluators = accessEvaluators;
    }

    public EvaluateAttribute(params Type [] accessEvaluators)
    {
        _accessEvaluators = accessEvaluators;
    }
    [Evaluate(typeof(CatEvaluator), typeof(DogEvaluator)]
    public SomeClass{ }

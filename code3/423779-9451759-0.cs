    public void BusinessLogicMethod()
    {
        var initialValue = MySingleton.Instance.GetInitialValue();
        var processedValue = initialValue + specialSomething + businessLogic;
        MySingleton.Instance.SaveProcessedValue(processedValue);
    }

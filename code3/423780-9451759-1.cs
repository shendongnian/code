    public void BusinessLogicMethod()
    {
        var singleton = ServiceLocator.Resolve<MySingleton>();
        var processedValue = singleton.InitialValue + specialSomething + businessLogic;
        singleton.SaveProcessedValue(processedValue);
    }

    foreach(var integrationType in loadedIntegrations)
    {
        var ctor = integrationType.GetConstructor(new Type[] { });
        var integration = ctor.Invoke(new object[] { }) as IntegrationInterface;
        //call methods on integration
    }

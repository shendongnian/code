    public void MainMethod_InInterfaceLayer()
    {
        // container is an instance of UnityContainer
        Person newPerson = container.Resolve<IPerson>();
    }

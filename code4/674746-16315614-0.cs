    /// <summary>
    /// Enables meta data output for a service host.
    /// </summary>
    /// <param name="host">The service host.</param>
    /// <remarks>Must be invoked prior to starting the service host.</remarks>
    public static void SetupMetaDataBehaviour(ServiceHost host)
    {
        ServiceMetadataBehavior metaDataBehaviour = host.Description.Behaviors.Find<ServiceMetadataBehavior>();
        if (metaDataBehaviour == null)
        {
            metaDataBehaviour = new ServiceMetadataBehavior();
            metaDataBehaviour.HttpGetEnabled = true;
            host.Description.Behaviors.Add(metaDataBehaviour);
        }
        else
        {
            metaDataBehaviour.HttpGetEnabled = true;
        }
    }

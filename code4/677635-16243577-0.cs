    ParseArguments(args);
    ProcessCheckServerCertificate();
    
    // upload the package created during the build to Azure BLOB
    var packageUrl = UploadFileToBlob(package);
    var services = new ListHostedServicesCommand();
    services.Run();
    hostedServices = services.HostedServices;
    .
    .
    .
    foreach (var hostedService in hostedServices)
    {
        Console.WriteLine("updating: " + hostedService.ServiceName);
        // get the deployment unique name - required for upgrade
        AzureCommand.HostedServiceName = hostedService.ServiceName;
        AzureCommand.DeploymentName = null;
        var getDeployment = new GetDeploymentCommand();
        getDeployment.Run();
        AzureCommand.DeploymentName = getDeployment.Deployment.Name;
    
        // upgrade the existing deployment    
        var upgradeDeployment = new UpgradeDeploymentCommand();
        upgradeDeployment.Run();
        servicesOperations.Add(upgradeDeployment.TrackingId, upgradeDeployment.ServiceManagement);
    }
    .
    .
    .
    // check status of all operations submitted
    foreach (var servicesOperation in servicesOperations)
    {
        // check status of operations
        AzureCommand.WaitForAsyncOperation(servicesOperation.Value, servicesOperation.Key);
    }

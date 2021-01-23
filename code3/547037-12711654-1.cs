    foreach (SPService service in SPFarm.Local.Services)
    {
        if (service.Name.Equals("ServiceName"))
        {
            foreach (SPServiceApplication serviceApp in service.Applications)
            {
                SPIisWebServiceApplication webServiceApp = (SPIisWebServiceApplication) serviceApp;
                SPIisWebServiceApplicationPool appPool = webServiceApp.ApplicationPool;
            }
        }
    }

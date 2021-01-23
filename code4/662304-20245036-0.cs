    /* Using in System.ServiceModel.dll */
        using System.ServiceModel.Configuration;
        using System.Web.Configuration;
    
        /* Inside any method  */
        var clientSection = ((ClientSection)(WebConfigurationManager.GetSection("system.serviceModel/client")));
                    if (clientSection != null)
                    {
                        foreach (ChannelEndpointElement endPoint in clientSection.Endpoints)
                        {
                            ..... endPoint.Name / endPoint.Address etc.
                        }
                    }

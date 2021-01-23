    try
    {
      //create service proxy and call service
    }
    catch (Exception ex)
    {
      Console.WriteLine(((System.ServiceModel.FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)(ex)).Detail.TraceText);
    }

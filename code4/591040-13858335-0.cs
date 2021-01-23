    Service1Client serviceClient = new Service1Client();
    using (new System.ServiceModel.OperationContextScope((System.ServiceModel.IClientChannel)serviceClient.InnerChannel))
    {
        System.ServiceModel.Web.WebOperationContext.Current.OutgoingRequest.Headers.Add("AdminGUID", "someGUID");
        serviceClient.GetData();
    }

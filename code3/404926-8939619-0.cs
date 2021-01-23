    private delegate void ServiceAction(Service.ServiceClient client);
    private static void PerformServiceAction(ServiceAction serviceAction)
    {
      using (var client = new Service.ServiceClient())
      {
        serviceAction(client);
      }
    }

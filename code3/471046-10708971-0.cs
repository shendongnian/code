    ServiceClient client = new ServiceClient();
     try {
         client.Operation();
     }
     catch(Exception ex)
     {
         if (client.State == CommunicationState.Faulted)
         {
                 client.Abort();
                 client = new ServiceClient();
         }
     }

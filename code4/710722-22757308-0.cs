     public Client[] GetClients()
      {
         using (ClientEntities context = new ClientEntities ())
           {
              context.Configuration.LazyLoadingEnabled = false;
              context.Configuration.ProxyCreationEnabled = false;
              return context.Client.ToArray();
            }
      }

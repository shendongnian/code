         private void SetProviderConnectionString(string connectionString)
         {
             var connectionStringField = 
             Membership.Provider.GetType().GetField("_sqlConnectionString", 
                         BindingFlags.Instance | BindingFlags.NonPublic);
             if (connectionStringField != null)
                 connectionStringField.SetValue(Membership.Provider, connectionString);
         }

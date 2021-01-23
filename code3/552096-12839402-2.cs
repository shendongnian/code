    private void SetMembershipProviderConnectionString(string connectionString)
    {
       // Set private property of Membership. Untested code!!
       var connectionStringField = Membership.Provider.GetType().GetField("_sqlConnectionString", BindingFlags.Instance | BindingFlags.NonPublic);
       if (connectionStringField != null)
          connectionStringField.SetValue(Membership.Provider, connectionString);
           
    }

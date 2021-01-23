    var errorProvider = OT.ConnectTo("(local)", "TestOTLab");
    if (errorProvider != null)
    {
       var errorMessage = errorProvider.ErrorMessage;
       var connectionStatus = errorProvider.ConnectionStat;
       var connectionDetails = errorProvider.ConnectionDetails;
       
       if (connectionDetails != null)
       {
           var serverID = connectionDetails.ServerID;
           \\insert other variables here...
       }
    }

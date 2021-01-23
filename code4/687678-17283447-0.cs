    public override ServiceHostBase CreateServiceHost(string constructorString, Uri[] baseAddresses)
    {
        try {
            return base.CreateServiceHost(constructorString, baseAddresses);
        }
        catch (Exception ex) {
            // log here
            throw;
        }
    }
